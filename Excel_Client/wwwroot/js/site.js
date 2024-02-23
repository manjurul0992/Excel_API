function submitForm() {
    var addedNcdList = document.getElementById('tblAddedNcdList');
    var ncdRows = addedNcdList.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    //console.log(ncdRows);

    var ncds = [];
    for (var i = 0; i < ncdRows.length; i++) {
        var selectedRowValue = ncdRows[i].getElementsByTagName('td')[0].getAttribute('value');
        //console.log(selectedRowValue);
        ncds.push(selectedRowValue);
    }
    console.log(ncds);

    var addedAllergyList = document.getElementById('tblAddedAllergyList');
    var allergyRows = addedAllergyList.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    //console.log(ncdRows);

    var allergies = [];
    for (var i = 0; i < allergyRows.length; i++) {
        var selectedRowValue = allergyRows[i].getElementsByTagName('td')[0].getAttribute('value');
        //console.log(selectedRowValue);
        /*ncds.push(selectedRowValue);*/
        allergies.push(selectedRowValue);
    }
    console.log(allergies);
}

function AddPatientNcds() {
    var selectedRow = $('#tblNcdList tbody tr .table-selected');
    selectedRow.removeClass('table-selected');
    selectedRow.parent().appendTo('#tblAddedNcdList tbody');
}

function RemovePatientNcds() {
    var selectedRow = $('#tblAddedNcdList tbody tr .table-selected');
    selectedRow.removeClass('table-selected');
    selectedRow.parent().appendTo('#tblNcdList tbody');
}

function AddPatientAllergies() {
    var selectedRow = $('#tblAllergyList tbody tr .table-selected');
    selectedRow.removeClass('table-selected');
    selectedRow.parent().appendTo('#tblAddedAllergyList tbody');
}

function RemovePatientAllergies() {
    var selectedRow = $('#tblAddedAllergyList tbody tr .table-selected');
    selectedRow.removeClass('table-selected');
    selectedRow.parent().appendTo('#tblAllergyList tbody');
}

$(document).ready(function () {
    $('#tblNcdList tbody tr td').click(function () {
        $('#tblNcdList tbody tr td').removeClass('table-selected');
        $(this).addClass('table-selected');
    });

    $('#tblAddedNcdList tbody tr td').click(function () {
        $('#tblAddedNcdList tbody tr td').removeClass('table-selected');
        $(this).addClass('table-selected');
    });

    $('#tblAllergyList tbody tr td').click(function () {
        $('#tblAllergyList tbody tr td').removeClass('table-selected');
        $(this).addClass('table-selected');
    });

    $('#tblAddedAllergyList tbody tr td').click(function () {
        $('#tblAddedAllergyList tbody tr td').removeClass('table-selected');
        $(this).addClass('table-selected');
    });

    $('#tblNcdList tbody tr').click(function () {
        var selectedData = {
            NCD_Id: $(this).find('td').attr('value'),
            NCD_Name: $(this).find('td').text().trim()
        };

        console.log(selectedData); // Output the selected data to the console
    });
});

