$(document).ready(function () {

    /*GetAll('#VTypeId', '/Manufacture/GetVehicleType'); */


    /*changedropdown('#VTypeId', '#ManufactureId', '/Manufacture/GetManufactureType?id=');*/
    
    var dataTableoption =
    {


        "searching": true,
        "ordering": true,
        "responsive": true,
        order: [[0, 'desc']],
        scrollCollapse: true,
        scrollY: '320px',

        "ajax": {
            "url": "/Manufacture/GetManufactureData",
            "dataSrc": "",

        },
        "columns": [
            { "targets": 0, "data": "sl", "sortable": true },
            { "targets": 1, "data": "manufactureType", "sortable": true },
            { "targets": 2, "data": "modelType", },
            {
                "targets": 3, "data": "manufactureId",
                "render": function (data, type, row, meta) {

                    return `<button type="submit" class="btn btn-info btn-sm" onclick="Update(${data})" value='${data}'>
                                                <i class="fas fa-pencil-alt">
                                                </i>
                                                Edit
                                            </button>
                                            <button type="submit" class="btn btn-danger btn-sm show-bs-modal" onclick="Delete(${data})" value='${data}'>
                                                <i class="fas fa-trash">
                                                </i>
                                                Delete
                                            </button>`;

                }, "sortable": false,
                "searchable": false,
                "visible": true
            }
        ]
    };
    $('#ManufactureTable').DataTable(dataTableoption);

});
function Update(id) {
    window.scrollTo(0, 0);

    $.ajax({
        url: '/Manufacture/Edit?id=' + id,
        success: function (result) {
            $('#ManufactureName').val(result.manufactureType);
            
            $('#ModelName').val(result.modelTypeName);
            $('#ManufactureId').val(result.manufactureId);
            
        }
      
    });
    $("#formButton").html("Update");
    $("#formButton").attr('formaction', "/Manufacture/Edit"); 
};

function Delete(id) {
    location.reload();
    $.ajax({
        "method":"post" ,
        url: '/Manufacture/Delete?id=' + id,
    });
}

//function GetAll(ID, Urls) {
//    $.ajax({

//        url: Urls,

//        success: function (result) {
//            $.each(result, function (i, data) {
//                $(ID).append('<option value=' + data.id + '>' + data.vehicleName + '</option > ');

//                console.log(result);


//            });


//        }

//    });
//}

//function changedropdown(id, changeid, URL) {
//    $(id).change(function () {
//        var id = $(this).val();
//        $(changeid).empty();
//        $(changeid).append('<option> select </option>');
//        $.ajax({
//            url: URL + id,
//            success: function (result) {
//                $.each(result, function (i, data) {
//                    $(changeid).append('<option value=' + data.id + '>' + data.name + ' </option> ');
//                    console.log(result);
//                });
//            }
//        });
//    });
//};
