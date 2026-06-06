$(document).ready(function () {

    // CEP automático
    $('#cep').on('blur', async function () {
        const cep = $(this).val().replace('-', '').trim();

        if (cep.length !== 8) return;

        const response = await fetch(`/Cliente/GetEnderecoPorCep?cep=${cep}`);

        if (!response.ok) {
            alert('CEP não encontrado.');
            return;
        }

        const data = await response.json();
        $('#endereco').val(data.logradouro);
        $('#cidade').val(data.localidade);
        $('#estado').val(data.uf);
    });

});