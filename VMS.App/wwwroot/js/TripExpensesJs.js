$(document).ready(function () {
 
    $('.overTimeGroup').hide();
    $('#OvertimeStatus').change(function () {
        var id = $(this).val();
        if (id == 1) {
            $('.overTimeGroup').show();
        };
        if (id == 0) {
            $('.overTimeGroup').hide();
        };


      
    });

    $('#tollAddButton').on('click', function () {
        alert('okk');
       
        $(`<div class="col-md-3 col-sm-3 col-lg-3 mb-2 tollDataGroup">
         <div class= "form-group" >
         <label class="control-label">Toll Name</label>
          <input asp-for="TollName" type="number" id="TollName" class=" form-control update-group">
                    </div>
                </div>


                <div class="col-md-3 col-sm-3 col-lg-3 mb-2 tollDataGroup">
                <div class="form-group ">
                    <label class="form-label">Toll Fee</label>
                    <input asp-for="TollFee" type="text" id="TollFee" class="form-control update-group">

                </div>

            </div>`).appendTo('#formRow');
    });

});

