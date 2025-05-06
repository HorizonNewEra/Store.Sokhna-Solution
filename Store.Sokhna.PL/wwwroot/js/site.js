//Equipments
const num1Input = document.getElementById('HourCount');
const num2Input = document.getElementById('HourPrice');
const resultInput = document.getElementById('TotalPrice');
num1Input.addEventListener('input', calculateSum);
num2Input.addEventListener('input', calculateSum);

function calculateSum() {
    const num1 = parseFloat(num1Input.value);
    const num2 = parseFloat(num2Input.value);
    if (!isNaN(num1) && !isNaN(num2)) {
        const sum = num1 * num2;
        const roundedSum = sum.toFixed(2);
        resultInput.value = roundedSum;
    } else {
        resultInput.value = '';
    }
}

function changeImage(newSource) {
    document.getElementById("Imgchange").src = newSource;
}
function changeImporter(newSource) {
    document.getElementById("ImporterEdit").value = newSource;
}