$(document).ready(function () {

    



    var dataTableoption =
    {


        "searching": true,
        "ordering": true,
        "responsive": true,
       /* order: [[0, 'desc']],*/
        "ajax": {
            "url": "/Vehicle/GetAllTableData",
            "dataSrc": "",
            

        },
        "columns": [
            { "targets": 0, "data": "sl", "sortable": true },
            { "targets": 0, "data": "regNo", "sortable": true },
            {
                "targets": 1, "data": "regEx",
               /* "render": "DataTable.render.datetime('Do DD MM YYYY')",*/ "sortable": true
            },
            
            //{
            //    "targets": 3, "data": "vehicleType",
            //   /* "render": DataTable.render.datetime('Do DD MM YYYY'),*/ "sortable": true
            //},
            { "targets": 4, "data": "modelType", "sortable": true }, 
            //{ "targets": 6, "data": "engine", "sortable": true },
            
            { "targets": 6, "data": "capacity", "sortable": true },
            {
               
                "targets": 7, "data": "vehicleId",
                "render": function (data, type, row, meta) {
                    return `<a onclick="Update(${data})" class="btn btn-info btn-sm"  value='${data} '>
                                                <i class="fas fa-pencil-alt">
                                                </i>
                                                Edit
                                            </a>
                                       
                                            <button type="submit" onclick="modalView(${data})" class="btn btn-success btn-sm show-bs-modal" data-toggle="modal" data-target="#exampleModal" onclick="Detail(${data})"  value='${data}'>
                                                <i class="fa fa-eye"></i>
                                               Details 
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



    $('#myTable').DataTable(dataTableoption);

    
    //var $example = $('#VehicleType').select2({
    //    theme: "classic"
    //});
    //$('#ModelType').on("click", function () {
    //    GetAll('#ModelType', '/Manufacture/GetModelType')
    //    $example.val().trigger("change");
    
    //});
   
    GetAll('#Manufactureid', '/Manufacture/GetManufacture');
    GetAll('#vehicleMode', '/TransportAgency/GetAllAgency');
    GetVehicleType('#VehicleCategoryId', '/Vehicle/GetVehicleType'); 

    changedropdown('#Manufactureid', '#Modelid');
    $('#modalbutton').on('click', '.bd-example-modal-lg', function (event) {
        ('.bd-example-modal-lg').modal('show');
    });
    $('#modalClose').on('click', function () {
        $('#exampleModal').modal('hide');
    });
});


function GetAll(ID, Urls) {
   
    $.ajax({

        url: Urls,

        success: function (result) {
            $.each(result, function (i, data) {
                $(ID).append('<option   value=' + data.manufactureId + '>' + data.manufactureName + '</option > ');

                console.log(result);


            });


        }

    });
}
function GetVehicleType(ID, Urls) {

    $.ajax({

        url: Urls,

        success: function (result) {
            $.each(result, function (i, data) {
                $(ID).append('<option   value=' + data.id + '>' + data.vehicleName + '</option > ');

                console.log(result);


            });


        }

    });
}

function changedropdown(id, changeId) {
    $(changeId).empty();
    $(changeId).append('<option>Select Model</option > ');

    $(id).change(function () {
        var id = $(this).val();
        /*    changedropdown(id);*/

        $(changeId).empty();
        $(changeId).append('<option>Select</option > ');
        $.ajax({
            url: '/Manufacture/GetModel?id=' + id,
            success: function (result) {

                //var year = new Date(result.year);

                //$('#modelYear').val(year.getFullYear());
                //$('#vehicleType').val(result.vehicleIsStanderd);
                //$('#vehicleCategory').val(result.vehicleType);
                $.each(result, function (i, data) {

                    $(changeId).append('<option   value=' + data.modelid + '>' + data.modelName + '</option > ');
                    console.log(result);
                });
            }
        });
    });
};
function Update(id) {

    $('#dataTable').hide();
    $('#EditPage').css("display", "unset");
    UpdateAjax(id);
  
   /* $(window).on('load', UpdateAjax(id) );*/
}
function UpdateAjax(id)
{
    

        /*    window.location.href='/vehicle/create'*/
        //window.scrollTo(0, 0);

        $.ajax({
            url: '/Vehicle/GetSingleObject?id=' + id,
            success: function (result) {
                console.log(result);
                $('#VehicleId').val(result.vehicleId);

                $('#Manufactureid').val(result.manufactureId);
                changeModel(result.manufactureId);
                $('#Modelid').val(result.vahicleModelId);
                //GetVehicleType('#VehicleCategoryId', '/Vehicle/GetVehicleType');
                $('#VehicleCategoryId').val(result.vehicleCategoryId);
                $('#modelYear').val(result.modelYear);
                $('#vehicleTypeId').val(result.vehicleTypeId);
                $('#colorId').val(result.colorId);
                $('#vehicleMode').val(result.vehicleMode);
                $('#VehicleMileage').val(result.vehicleMileage);
                var vehicleCapacity = result.vehicleCapacity.split(" ");
                if (vehicleCapacity[1].length == 3) {

                    $('#VehicleCapacityId').val(0);
                    //Console.log(vehicleCapacity[1]);
                    //Console.log(vehicleCapacity[0]);

                }
                else {
                    $('#VehicleCapacityId').val(1);
                }
                $('#VehicleCapacity').val(vehicleCapacity[0]);

                $('#RegNo').val(result.regNo);
                $('#RegDate').val(result.regDate);
                $('#Reg_Expired').val(result.regEX);
                $('#fitness_TaxToken').val(result.fitnessToken);
                $('#fitnessExpireDate').val(result.fitnessExpiry);
                $('#Chassis').val(result.chasiss);
                $('#engine').val(result.engine);

                

                //var year = new Date(result.year);

                //$('#modelYear').val(year.getFullYear());
                //$('#vehicleType').val(result.vehicleIsStanderd);
                //$('#vehicleCategory').val(result.vehicleType);

                console.log(result);

            }
        });
        $("#formButton").html("Update");
        /* $("#formButton").setAttribute("Form-Action","/Vehicle/Edit");*/
        $(".update-group").addClass("border-info");
        //$("#Document").setAttribute("disabled", "disabled");
        $("#Photo").hide();
        $("#Document").hide();
        $('#formButton').attr('formaction', "/vehicle/Edit");
   
}

function changeModel(id) {

    $('#Modelid').empty();
               $.ajax({
                   url: '/Manufacture/GetModel?id=' + id,
                    success: function (result) {

                        
                        $.each(result, function (i, data) {

                            $('#Modelid').append('<option   value=' + data.modelid + '>' + data.modelName + '</option > ');
                            console.log(result);
                        });
                    }
                });

              
              
}
function modalView(id) {

    var modal = $('#exampleModal');

    $.ajax({
        url: '/Vehicle/GetSingleObject?id=' + id,
        success: function (result) {
            $('#CategoryModal').val(result.vehicleCategoryName);
            $('#ModelModal').val(result.vahicleModelName);
            $('#ManufactureModal').val(result.manufactureName);
            $('#ColorModal').val(result.colorName);
            $('#YearModal').val(result.modelYear);
            $('#ModeModal').val(result.vehicleModeName);
            $('#TypeModal').val(result.vehicleTypeName);
            $('#vehicleMileageModal').val(result.vehicleMileage);
         
            $('#VehicleCapacityModal').val(result.vehicleCapacity);
            $('#RegistrationModal').val(result.regNo);
            $('#RegistrationDateModal').val(result.regDate);
            $('#RegistrationExDate').val(result.regEX);
            $('#TokenModal').val(result.fitnessToken)
            $('#TokenExDateModal').val(result.fitnessExpiry);
            $('#ChasissModal').val(result.chasiss);
            $('#EngineModal').val(result.engine);
            console.log(result);
        }
    });
    modal.modal('show');
    $('#viewbutton').on('click', function (event) {
       
    });

} 

     
function Delete(id)
{
    location.reload();
    $.ajax({
        url:"/vehicle/SoftDelete?id="+id,
    });
}

