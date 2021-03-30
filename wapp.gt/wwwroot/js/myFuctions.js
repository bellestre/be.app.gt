function info() {
       swal({
        title: "¿Desea Continuar papu? ",
        text: "No podrás deshacer este paso",
        icon: "warning",
        buttons: true,
        successMode: true,
    })
        .then((willDelete) => {
            
            if (willDelete) {

                swal("¡Hecho!", "Registro guardado", "success");
                document.getElementById("form_id").submit();
            }
        });
}

function prueba() {
    var credito = document.getElementById("Creditos").value; 
    //alert("ALERTA PAPU " + credito);
    alertify.defaults.transition = "slide";
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";
    alertify.defaults.theme.input = "form-control";

    if (credito >= 160) {
        alertify.confirm('¿Desea Continuar?', 'No podrás deshacer este paso',
            function () {
                alertify.success('Registro guardado')
                document.getElementById("form_id").submit();
            },
            function () {
                alertify.error('Cancel')
            });

    } else {
        alertify.error('El credito es menor a 160');
    }
   
}

function addAsesor() {
    var form = $("form_asesor");
    //alert("ALERTA PAPU " + credito);
    alertify.defaults.transition = "slide";
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";
    alertify.defaults.theme.input = "form-control";
    //if ($('form_asesor > :input[required]:visible').val() != "")
    if (form.val() != "") {
        alertify.confirm('¿Desea Continuar?', 'No podrás deshacer este paso',
            function () {
                alertify.success('Registro guardado')
                document.getElementById("form_asesor").submit();
            },
            function () {
                alertify.error('Cancel')
           });
    }else {
        alertify.error('Error');
    }

}

function confirm() {
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";

    alertify.confirm('¿Desea Continuar?', 'No podrás deshacer este paso',
        function () {
            alertify.success('Registro guardado')
            document.getElementById("form_rama").submit();

        },
        function () {
            alertify.error('Cancel')
        }
    );
}

function confirmar() {
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-default";

    alertify.confirm('¿Desea Continuar?', 'No podrás deshacer este paso',
        function () {
            alertify.success('Registro guardado')
            document.getElementById("form_tesis").submit();

        },
        function () {
            alertify.error('Cancel')
        }
    );
}

function open(x) {
    $(x).modal('show');
}

function verModal() {
    var modalito = $("#eventModal");
    modalito('show');
}

function miModal() {
    $('#eventModal').modal('show'); 
}

function miMapa(){
    $('#ModalMapPreview').locationpicker({
        radius: 0,
        location: {
            latitude: -9.313168,
            longitude: -75.996661
        },
        inputBinding: {
            latitudeInput: $('#ModalMap-lat'),
            longitudeInput: $('#ModalMap-lon'),
            locationNameInput: $('#Map-address')

        },
        enableAutocomplete: true,
        onchanged: function (currentLocation, radius, isMarkerDropped) {
            $('#ubicacion').html($('#Map-address').val());
        }
    });
    $('#ModalMap').on('shown.bs.modal', function () {
        $('#ModalMapPreview').locationpicker('autosize');
    });

}
