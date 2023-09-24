$(document).ready(function () {

    var dataOption = {


        "searching": true,
        "ordering": true,
        "responsive": true,
        order: [[0, 'desc']],
        "ajax": {
            "url": "/TransportAgency/GetAllTableData",
            "dataSrc": "",


        },
        "columns": [
            { "targets": 0, "data": "sl", "sortable": true },
            { "targets": 1, "data": "name", "sortable": true },
            {
                "targets": 2, "data": "owner", "sortable": true
            },
            {
                "targets": 3, "data": "phoneNumber", "sortable": true
            },

            {
                "targets": 4, "data": "address", "sortable": true
            },
         
            {

                "targets": 5, "data": "id",
                "render": function (data, type, row, meta) {
                    return `<button type="submit" class="btn btn-info btn-sm" onclick="Update(${data})" value='${data}'>
                                                <i class="fas fa-pencil-alt">
                                                </i>
                                                Edit
                                            </button>
                                          <button type="submit" class="btn btn-danger btn-sm "  onclick="Delete(${data})" value='${data}'>
                                                <i class="fas fa-trash">
                                                </i>
                                                Delete
                                            </button>`;

                },
                "sortable": false,
                "searchable": false,
                "visible": true
            }
        ]
    };





    $('#TransportAgencyTable').DataTable(dataOption);
});



function Update(id) {
    window.scrollTo(0, 0);

    $.ajax({
        url: '/TransportAgency/Get?id=' + id,
        success: function (result) {
            $('#AgencyName').val(result.name);
           
            $('#Owner').val(result.owner);
            $('#PhoneNumber').val(result.phoneNumber);

            $('#Address').val(result.address);
            $('#TransportAgencyId').val(result.id);
            console.log(result);

        }
    });
    $("#formButton").html("Update");

    $(".update-group").addClass("border-info");

    $('#formButton').attr('formaction', "/TransportAgency/Edit")
}

function Delete(id) {
    window.scrollTo(0, 0);
    location.reload();
    $.ajax({
        "method": "post",
        url: '/TransportAgency/Delete?transportAgencyId=' + id,
    });
    
}