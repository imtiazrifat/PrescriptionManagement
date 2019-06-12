$(document).ready(function () {
    //$.getJSON("/echo/json/",function(obj)
    //{
    //    $.each(json.cars,function(key,value)
    //    {
    //        var option = $('<option />').val(value.carID).text(value.CarType);
    //        $("#dropDownDest").append(option);
    //    });

    //});
    debugger;
    $.ajax({

        url: "/GenaratePrescription/GetAllPatient",
        type: "GET",
        // data: JSON.stringify({ 'aProduct': order }),
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            debugger;
            var option = $('<option />').val(null).text('Select one patient');
            $("#dropDownDest").append(option);
            $.each(data.data, function (key, value) {
                option = $('<option />').val(value.Id).text(value.PatientName);
                $("#dropDownDest").append(option);
            });
        },

        error: function () {
            debugger;
            $('#ModelBody').html("Sorry Some Error Occoured");
            alert("An error has occured!!!");
        }

    });


    $('#dropDownDest').on('change', function () {
        debugger;
        var patientId = this.value; // or $(this).val()
        $.ajax({

            url: "/GenaratePrescription/GetAPatient",
            type: "POST",
            data: JSON.stringify({ 'id': patientId }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger;
                //$('#loadProductCode').attr("data-myval", data.ProductCode);
                //$('#loadProductDetails').attr("data-myval", data.ProductDetails);
                //$('#loadProductName').attr("data-myval", data.ProductName);
                //$('#loadProductCode').val(data.ProductCode);

                // loadProductCode.dataset.myval = data.ProductCode;


                $('#PatientID').val(data.PatientImageId);
                $('#PatientMobile').val(data.PatientMobile);
                $('#PatientDBO').val(data.DateBecameCustomer);
                //if (data.status == "Success") {
                //    $('#myModal').modal('show');
                //  //  modelData
                //   // alert(data.data);
                //    $(element).closest("form").submit(); //<------------ submit form
                //} else {
                //    alert("Error occurs on the Database level!");
                //}
            },

            error: function () {
                debugger;
                alert("An error has occured!!!");
            }

        });




        //$.ajax({

        //    url: "/GenaratePrescription/GetAPatient/" + patientId,
        //    type: "GET",
        //    // data: JSON.stringify({ 'aProduct': order }),
        //    dataType: "json",
        //    traditional: true,
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        debugger;
        //        $('#PatientID').val(data.PatientImageId);
        //        $('#PatientMobile').val(data.PatientMobile);
        //        $('#PatientDBO').val(data.DataBecameCustomer);
        //        //var option = $('<option />').val(null).text('Select one patient');
        //        //$("#dropDownDest").append(option);
        //        //$.each(data.data, function (key, value) {
        //        //    option = $('<option />').val(value.Id).text(value.PatientName);
        //        //    $("#dropDownDest").append(option);
        //        //});
        //    },

        //    error: function () {
        //        debugger;
        //        $('#ModelBody').html("Sorry Some Error Occoured");
        //        alert("An error has occured!!!");
        //    }

        //});
    });


});

//searching and adding medicine to list starts
var tempMedicineId;
$(document).ready(function () {
    $("#medicineName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/DrugDetails/Getmed",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                selectFirst: true,
                success: function (data) {
                    debugger;

                    response($.map(data, function (item) {
                        return { label: item.DrugName, value: item.Id };
                    }));

                }
            });
        },

        select: function (event, ui) {
            debugger;
            $("#medicineName").val(ui.item.label);
            tempMedicineId = ui.item.value;


            $('#medicineName1').val(ui.item.label);

            $('#myModal').modal('show');


            //$("#tempMedicineId").val(ui.item.value);

            return false;
        },
        //focus: function (event, ui) {
        //    // this is for when focus of autocomplete item 
        //    $("#medicineName").val(ui.item.name);
        //    return false;
        //},



        //messages: {
        //    noResults: "",
        //    results: ""
        //}
    });
    $("#takingProceduremanual").hide();
    $("#takingProcedure").on('change', function () {
        debugger;
        var check = this.value;
        $("#takingProceduremanual").hide();
        if (check == "Other") {
            $("#takingProceduremanual").show();
        }
    });

    var totalMedicineData = [];

    $('#addMedicine').click(function (e) {
        debugger;
        var id = tempMedicineId;
        var medicineName1 = $('#medicineName1').val();

        var takingProcedure = $('#takingProcedure').val();
        var takingProceduremanual = $('#takingProceduremanual').val();

        var drugQuantity = $('#drugQuantity').val();
        var quantityMeasurement = $('#quantityMeasurement').val();
        var specialInstruction = $('#specialInstruction').val();

        debugger;
        if (takingProcedure == 'Other') {
            takingProcedure = $('#takingProceduremanual').val();
        }
        var aData = {
            Id: id,
            medicineName: medicineName1,

            takingProcedure: takingProcedure,
            takingProceduremanual: takingProceduremanual,
            drugQuantity: drugQuantity,
            quantityMeasurement: quantityMeasurement,
            specialInstruction: specialInstruction

        }

        totalMedicineData.push(aData);
        generateMedicineTable();


    });


    function generateMedicineTable() {
        // alert('hi');
        var tr;
        $("#tbodyid").empty();
        for (var i = 0; i < totalMedicineData.length; i++) {
            tr = $('<tr/>');
            tr.append("<td>" + (i + 1) + ".</td>");
            tr.append("<td>" + totalMedicineData[i].Id + "</td>");
            tr.append("<td>" + totalMedicineData[i].medicineName + "</td>");
            tr.append("<td>" + totalMedicineData[i].takingProcedure + "</td>");
            tr.append("<td>" + totalMedicineData[i].drugQuantity + "-" + totalMedicineData[i].quantityMeasurement + "</td>");
            tr.append("<td>" + totalMedicineData[i].specialInstruction + "</td>");
            tr.append("<td>" + "<button type='button' id='btn' class='btn btn-danger' onClick='myFunction2(" + totalMedicineData[i].Id + ");' >" + "Remove" + "</button>" + "</td>");
            $("#tbodyid").append(tr);
        }
    }
    //searching and adding medicine to list ends
    var tempMedicalTestId;
    $("#testName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/MedicalTest/GetTest",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                selectFirst: true,
                success: function (data) {
                    debugger;

                    response($.map(data, function (item) {
                        return { label: item.MedicalTestName, value: item.Id };
                    }));

                }
            });
        },

        select: function (event, ui) {
            debugger;
            $("#testName").val(ui.item.label);
            tempMedicalTestId = ui.item.value;


            $('#MedicalTestId1').val(ui.item.label);

            $('#myModalTest').modal('show');


            //$("#tempMedicineId").val(ui.item.value);

            return false;
        },
        //focus: function (event, ui) {
        //    // this is for when focus of autocomplete item 
        //    $("#medicineName").val(ui.item.name);
        //    return false;
        //},



        //messages: {
        //    noResults: "",
        //    results: ""
        //}
    });


    var totalMedicalTestData = [];

    $('#addMedicalTest').click(function (e) {
        debugger;
        var id = tempMedicalTestId;
        var medicalTestId1 = $('#MedicalTestId1').val();

        var beforeOrAfter = $('#beforeOrAfter').val();
        var medicalTestAdvice = $('#MedicalTestAdvice').val();


        var aData = {
            MedicalTestId: id,
            MdicalTestName:medicalTestId1,
            SpecialInstruction: medicalTestAdvice,

            BeforeOrAfter: beforeOrAfter,
            

        }

        totalMedicalTestData.push(aData);
        generateMedicalTestTable();


    });


    function generateMedicalTestTable() {
        // alert('hi');
        var tr;
        $("#tbodyMedicineid").empty();
        for (var i = 0; i < totalMedicalTestData.length; i++) {
            tr = $('<tr/>');
            tr.append("<td>" + (i + 1) + ".</td>");
            tr.append("<td>" + totalMedicalTestData[i].MedicalTestId + "</td>");
            tr.append("<td>" + totalMedicalTestData[i].MdicalTestName + "</td>");
            tr.append("<td>" + totalMedicalTestData[i].SpecialInstruction + "</td>");
           
            tr.append("<td>" + totalMedicalTestData[i].BeforeOrAfter + "</td>");
            tr.append("<td>" + "<button type='button' id='btn' class='btn btn-danger' onClick='myFunction2(" + totalMedicalTestData[i].Id + ");' >" + "Remove" + "</button>" + "</td>");
            $("#tbodyMedicineid").append(tr);
        }
    }
    //searching and adding Medical Test to list ends

    
    $('#addAdvice').click(function (e) {
        debugger;
       
        
        $('#myModal1').modal('show');
    });

});



//function LoadPatientDetails() {
//    debugger;
//    alert('hi');
//}
