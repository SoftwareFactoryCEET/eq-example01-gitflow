// Validar el contenido de los campos
function validarNumero(input) {
    var valor = input.value;
    var pattern = /^-?\d*([.]?\d+)?$/;

    if (!pattern.test(valor)) {
        input.setCustomValidity("Enter a valid number");
    } else {
        input.setCustomValidity("");
    }
}

// Obtener una referencia al formulario
const form = document.getElementById('myForm');

// Agregar evento de escucha para el envío del formulario
form.addEventListener('submit', function (event) {
    event.preventDefault(); // Evitar el envío del formulario por defecto

    // Obtener referencias a las cajas de texto
    const numero1Input = document.getElementById('Number1');
    const numero2Input = document.getElementById('Number2');

    // Verificar si las cajas de texto están vacías
    if (numero1Input.value.trim() === '' || numero2Input.value.trim() === '') {
        return; // Cancelar el envío del formulario si los campos están vacíos
    }

    // Si los campos no están vacíos, continuar con el envío del formulario
    sendData();
});

function sendData() {
    var operation = document.querySelector('input[name="operation"]:checked').value;
    var Number1 = document.getElementById('Number1').value;
    var Number2 = document.getElementById('Number2').value;

    // Verificar si los campos numero1 y numero2 están vacíos y asignarles un valor predeterminado en ese caso
    Number1 = Number1 === '' ? '0' : Number1;
    Number2 = Number2 === '' ? '0' : Number2;

    var data = { operation: operation, Number1: Number1, Number2: Number2 };

    axios.post('/Home/CalculartorAjax', data)
        .then(function (response) {
            mostrarResultado('Result: ' + response.data);
        })
        .catch(function (error) {
            console.error('Error en la solicitud: ' + error.response.status);
            window.location.href = '/Home/Error';
        });
}

function mostrarResultado(result) {
    var resultadoElement = document.getElementById('result');
    resultadoElement.textContent = result;
}

// Asociar la función enviarDatos al evento click del botón "Calcular"
var calcularBtn = document.getElementById('calcularBtn');
calcularBtn.addEventListener('click', sendData);