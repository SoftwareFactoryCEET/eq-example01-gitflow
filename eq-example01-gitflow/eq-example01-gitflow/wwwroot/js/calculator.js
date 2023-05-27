// Obtener una referencia al formulario
const form = document.getElementById("myForm");

// Agregar evento de escucha para el envío del formulario
form.addEventListener("submit", function (event) {
    event.preventDefault(); // Evitar el envío del formulario por defecto
});

// Obtener una referencia al botón "Calcular"
const calcularBtn = document.getElementById("calcularBtn");

// Agregar evento de escucha al botón "Calcular"
calcularBtn.addEventListener("click", function () {
    // Obtener referencias a las cajas de texto
    const numero1Input = document.getElementById("Number1");
    const numero2Input = document.getElementById("Number2");

    // Verificar si las cajas de texto están vacías
    if (numero1Input.value.trim() === "" || numero2Input.value.trim() === "") {
        return; // Cancelar el envío del formulario si los campos están vacíos
    }

    // Verificar si los valores son números válidos
    if (!validarNumero(numero1Input) || !validarNumero(numero2Input)) {
        return; // Cancelar el envío del formulario si los valores no son válidos
    }

    // Enviar los datos al controlador
    sendData();
});

function validarNumero(input) {
    let valor = input.value;
    let pattern = /^-?\d*([.]?\d+)?$/;

    if (!pattern.test(valor)) {
        input.setCustomValidity("Enter a valid number");
        return false;
    } else {
        input.setCustomValidity("");
        return true;
    }
}

function sendData() {
    let operation = document.querySelector('input[name="operation"]:checked')
        .value;
    let Number1 = document.getElementById("Number1").value || "0";
    let Number2 = document.getElementById("Number2").value || "0";

    let data = { operation: operation, Number1: Number1, Number2: Number2 };

    axios
        .post("/Home/CalculartorAjax", data)
        .then(function (response) {
            mostrarResultado("Result: " + response.data);
        })
        .catch(function (error) {
            console.error("Error en la solicitud: " + error.response.status);
            window.location.href = "/Home/Error";
        });
}

function mostrarResultado(result) {
    let resultadoElement = document.getElementById("result");
    resultadoElement.textContent = result;
}
