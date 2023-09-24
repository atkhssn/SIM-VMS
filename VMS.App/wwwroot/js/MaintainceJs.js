
$(document).ready(function () {
    var rowCount = parseInt($("#total").val());



});
function adding() {
    let z = 0;
    if (z == 0) {
        $('#tableDiv').css("display", "table");
        z++;
    }

    var rowCount = parseInt($("#total").val());
    var partsname = $('#PartsName').val().trim();
    var partsprice = $('#partsPrice').val().trim();
    var vachileid = $('#vehicleId').val();

    if (partsname != "" && partsprice != "") {


/*        $('table tbody').html("")*/;
        $('.odd').hide()
        $('#tablebody').append(`
                            <tr id="inputRow${rowCount}" >
                                        

                              <td>
                                 ${partsname}
                              </td>
                              <td>
                               ${partsprice}
                              </td>  
                              <td>
                              <a id="Edit${rowCount}" onclick="Edit(${rowCount})" class="btn btn-info btn-sm"  value='${rowCount}'>
                                                <i class="fas fa-pencil-alt">
                                                </i>
                                                Edit
                                            </a>
                                <button  class="btn btn-danger btn-sm "  onclick="DeleteParts(${rowCount})" >Remove
                              </td>
                             </tr>`);

        $('#PartsName').val('');
        $('#partsPrice').val('');
        rowCount++;
        $("#total").val(rowCount);

    }
};



//function AddParts() {
//    var rowCount = parseInt($("#total").val());
//    var Partsvalue = $('#Partsvalue').val().trim();
//    var Pricevalue = $('#Pricevalue').val().trim();
//        //$('#PartsName').push(Partsvalue);
//        //$('#PartsPrice').push(Pricevalue);
//    console.log($("#total").val());

//    if (Partsvalue != "" && Pricevalue != "") {


//        $('table tbody').html("");
//        $('table tbody').append(`
//                            <tr id="inputRow${rowCount}">
//                          <td name="[${(rowCount)}].PartsName" value=" ${Partsvalue}">
//                             ${Partsvalue}
//                          </td>
//                          <td name="[${(rowCount)}].PartsPrice" value="${Pricevalue}">
//                           ${Pricevalue}
//                          </td>
//                          <td>

//                           <button type="submit" class="btn btn-danger btn-sm "  onclick="DeleteParts(${rowCount})" >Remove
//                           </td>
//                      </tr>`);
//    }
//    //$('#table').append(`<input id="PartsName${(rowCount)}" name="[${(rowCount)}].PartsName" type="hidden" value="${Partsvalue}" />
//    //        <input id="PartsPrice${(rowCount)}" name="[${(rowCount)}].PartsPrice" type="hidden" value="${Pricevalue}" />`);


//    rowCount++;

//    $("#total").val(rowCount);
//    $('#Partsvalue').val('');
//   $('#Pricevalue').val('');
//};

function Edit(row) {

    var editId = '#Edit'.concat(row)
    var row = $(editId).closest('tr');
    var partsName = row.find('td:eq(0)').text().trim();
    var partsPrice = row.find('td:eq(1)').text().trim();
    var parts = $('#PartsName').val(partsName);
    console.log(partsName);
    var price = $('#partsPrice').val(partsPrice);
    console.log(partsPrice);
    alert('okk');





    // Get the data from the row cells
    var name = dataTable.row(row).data()[0]; // Assuming "Name" is in the first column
    console.log(name);
    var email = dataTable.row(row).data()[1];
    console.log(email);
}

function DeleteParts(rowNumber) {
    var rowCount = parseInt($("#total").val());


    var row = '#inputRow'.concat(rowNumber);
    var hiddenPartsName = '#PartsName$'.concat(rowNumber);
    var hiddenPrice = '#PartsPrice$'.concat(rowNumber);
    console.log(row);
    console.log(row);
    $(row).remove();
    //$(hiddenPartsName).remove();
    //$(hiddenPrice).remove();
    /*    $(row).reset();*/
    rowCount--;

    $("#total").val(rowCount);
    if (rowCount == 0) {
        $('#tableDiv').css("display", "none");
    }

    //z = o;
    //$('.Parts').each(function (index) {
    //    (this).attr('name', "["+index+"].PartsName");
    //    z++;
    //});
    //$('.Price').each(function (index) {
    //    (this).attr('name', "["+index+"].PartsPrice");
    //    z++;
    //});

    //for (let i = o; i <= rowCount; i++)
    //{
    //    var row = '#inputRow'.concat(i);
    //    var partsName = '#Parts'.concat(i);
    //    $(row).attr('name',)
    //}
};
function submit() {
    alert('okkk')

    var rowDataArray = [];

    // Iterate through each table row in the tbody
    $('#table tbody tr').each(function () {
        // Get the data from the current row cells
        var partsName = $(this).find('td:eq(0)').text().trim();
        var price = $(this).find('td:eq(1)').text().trim();

        var rowData = {
            Name: partsName,
            Price: price
        };
        console.log(rowData);
        // Push the rowData object to the array
        rowDataArray.push(rowData);
    });
    console.log(rowDataArray);

    var partsname = $('#PartsName').val();
    var partsprice = $('#partsPrice').val();
    var Description = $('textarea[name="Description"]').val();
    var status = $('select[name="Status"]').val();
    var serviceBill = $('input[name="WorkshopBill"]').val();
    var serviceDate = $('input[name="ServiceDate"]').val();
    var TripId = $('input[name="TripId"]').val();
    var vehicleId = $('input[name="VehicleId"]').val();


    $.ajax({
        url: '/Maintenance/Create', // Replace with your controller and action method
        type: 'POST',
        data: {
            PartsName: partsname,
            PartsPrice: partsprice,
            Description: Description,
            status: status,
            serviceBill: serviceBill,
            serviceDate: serviceDate,
            TripId: TripId,
            vehicleId: vehicleId,
            RowDataArray: rowDataArray
        },
        success: function (response) {
            // Handle the server response here
            console.log("okk");
        },
        error: function (error) {
            // Handle errors here
            console.error(error);
        }
    });
}

//function submit() {
//    alert('okkk')

//    var rowDataArray = [];

//    // Iterate through each table row in the tbody
//    $('#table tbody tr').each(function () {
//        // Get the data from the current row cells
//        var partsName = $(this).find('td:eq(0)').text().trim();
//        var price = $(this).find('td:eq(1)').text().trim();

//        var rowData = {
//            Name: partsName,
//            Price: price
//        };
//        console.log(rowData);
//        // Push the rowData object to the array
//        rowDataArray.push(rowData);
//    });
//    console.log(rowDataArray);
//    console.log(rowDataArray.mode);
//    var partsname = $('#PartsName').val();
//    var partsprice = $('#partsPrice').val();
//    var Description = $('textarea[name="Description"]').val();
//    var status = $('select[name="Status"]').val();
//    var serviceBill = $('input[name="WorkshopBill"]').val();
//    var serviceDate = $('input[name="ServiceDate"]').val();
//    var TripId = $('input[name="TripId"]').val();
//    var vehicleId = $('input[name="VehicleId"]').val();
//    var parameter = {

//        PartsName: partsname,
//        PartsPrice: partsprice,
//        Description: Description,
//        Status: status,
//        serviceBill: serviceBill,
//        serviceDate: serviceDate,
//        TripId: TripId,
//        vehicleId: vehicleId,
//        RowDataArray: rowDataArray
//    };
//    console.log(parameter);
//    console.log(parameter.mode);
//    $.ajax({
//        url: '/Maintenance/Create', // Replace with your controller and action method
//        type: 'POST',

//        data: parameter,
//        success: function (response) {
//            // Handle the server response here
//            console.log("okk");
//        },
//        error: function (error) {
//            // Handle errors here
//            console.error(error);
//        }
//    });

//}

    //$('#partsAddButton').on('click', function () {
    //    var z = 1;
    //    var partName = $('#PartsName');
    //    var partPrice = $('#partsPrice');
    //    var rowCount = parseInt($("#total").val());
    //    rowCount++;

    //    $("#total").val(rowCount);

    //    $('#formRowId').append(`                  <div class="col-md-6 mb-2">
    //                    <div class="form-group">
    //                        <label class="control-label ">Name of the Part</label>
    //                <input id="PartsName" name="[${(rowCount) }].PartsName" type="text"  value="" class="form-control" placeholder="Enter parts name">

    //                 </div>
    //                </div>


    //           <div class="col-md-6 mb-2 ">
    //            <label class="control-label"> parts price</label>
    //               <div class="form-group ">

    //                <input id="partsPrice" name="[${(rowCount)}].PartsPrice" type="text" class="form-control" value="" placeholder="Enter parts price">



    //                </div>
    //          </div>`);


    //});