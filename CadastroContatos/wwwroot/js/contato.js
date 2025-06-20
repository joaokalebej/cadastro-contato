$(document).ready(function () {
    getAllContatos();
    $(function () {
        $('[data-bs-toggle="popover"]').popover();
    });
});

function pesquisarContato() {
    const data = {
        Nome: $("#Nome").val(),
        Empresa: $("#Empresa").val(),
        TelefonePessoal: $("#TelefonePessoal").val(),
        TelefoneComercial: $("#TelefoneComercial").val(),
        Email: $("#Email").val(),
    };
    filtrarContato(data);
}

function filtrarContato(data) {
    debugger;
    $.ajax({
        type: 'GET',
        url: urlPesquisarContato,
        data: data,
        success: function (dados) {
            $("#grid-contatos").empty();
            $("#grid-contatos").html(dados);
            [].forEach.call(document.getElementsByClassName('grid-contato'), function (element) {
                var grid = new MvcGrid(element, {
                    url: urlPesquisarContato,
                    isAjax: true
                });
                grid.url.searchParams.set("Nome", dados.Nome);
                grid.url.searchParams.set("Empresa", dados.Empresa);
                grid.url.searchParams.set("TelefonePessoal", dados.TelefonePessoal);
                grid.url.searchParams.set("TelefoneComercial", dados.TelefoneComercial);
                grid.url.searchParams.set("Email", dados.Email);
            });
        },
        error: function (ex) {
            alert(ex.responseText, 'Erro!');
        }
    });
}

function deleteContato(id){
    $.ajax({
        url: urlDeleteContato,
        type: 'POST',
        data: {
            id: id 
        },
        success: function () {
            pesquisarContato();
        },
        error: function (dados) {
            alert(dados.responseText, "Erro!");
        }
    })
}

function addEmail() {
    const newInput = $(`
            <div class="input-group mb-2">
                <input type="email" name="Emails" class="form-control" placeholder="email@exemplo.com" />
            </div>
        `);
    $('#emailContainer').append(newInput);
}