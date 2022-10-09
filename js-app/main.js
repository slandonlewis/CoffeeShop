const url = "https://localhost:5001/api/beanvariety/";

const getBeansEl = document.querySelector("#run-button");
const beansEl = document.querySelector("#beans");
const formEl = document.querySelector("#form")

getBeansEl.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
            let stringOBeans = `<h2>Bean Varieties</h2>`;
            for (const bean in beanVarieties) {
                stringOBeans += `<b>Name:</b> ${beanVarieties[bean].name}, <b>Region:</b> ${beanVarieties[bean].region}, <b>Notes:</b> ${beanVarieties[bean].notes}<br>`
            }
            beansEl.innerHTML = stringOBeans;
        })
});

formEl.addEventListener('submit', e => {
    e.preventDefault();

    const formData = new FormData(formEl);
    const data = Object.fromEntries(formData);

    fetch("https://localhost:5001/api/beanvariety", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    });
})

function getAllBeanVarieties() {
    return fetch(url).then(resp => resp.json());
}