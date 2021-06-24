var urlWebAPI = "https://localhost:44372";

$('#btn_get').on("click", function () {
    GetPremiumTable();
})

$('.filterTable').change(function (event) {
    GetPremiumTable();
});

var elem = document.querySelector('input[name="calendar"]');
var datepicker = new Datepicker(elem, {
    autohide: true,
    clearBtn: true,
    format: 'dd/mm/yyyy'
});
elem.addEventListener('changeDate', function (e, details) {
    var ageDifMs = Date.now() - datepicker.getDate().getTime();
    var ageDate = new Date(ageDifMs);
    $('#txt_age').val(Math.abs(ageDate.getUTCFullYear() - 1970));
});

$('#txt_age').keyup(function (event) {
    this.value = this.value.replace(/[^0-9]/g, '');
    if (this.value.length > 2) {
        this.value
    }
});

function GetPremiumTable() {
    $('#thead').html("");
    $('#tbody').html("");
    var dateBirth = $('#txt_date').val();
    var state = $('#ddl_state').val();
    var plan = $('#ddl_plan').val();
    var age = $('#txt_age').val();
    var period = parseInt($('#ddl_period').val(), 10); // the number 10 is the radix
    var TableHead = "<tr><th>Carrier</th><th>Premium</th><th>Anual</th><th>Montly</th></tr>";
    $('#thead').html(TableHead);
    var tbody = "<tr><td><input type='textbox' disabled/></td><td><input type='textbox' disabled/></td>" +
        "<td><input type='textbox' disabled/></td><td><input type='textbox' disabled/></td></tr>";
    $.ajax({
        url: urlWebAPI + "/api/Premium/GetPremiumList?DateBirth=" + dateBirth + "&State=" + state + "&Age=" + age + "&Plan=" + plan,
        method: 'GET',
        success: function (response) {
            var Annual = 0;
            var Montly = 0;
            if (response != null) {
                if (response.length > 0) {
                    tbody = ""; // we will print the data only when we get a response 
                    for (var i = 0; i < response.length; i++) {
                        switch (period) {
                            case 1: Montly = response[i].premium / 1; Annual = response[i].premium * 12; break;
                            case 2: Montly = response[i].premium / 3; Annual = response[i].premium * 4; break;
                            case 3: Montly = response[i].premium / 6; Annual = response[i].premium * 2; break;
                            default: Montly = response[i].premium / 12; Annual = response[i].premium * 1; break;
                        }
                        tbody += "<tr><td><input type='textbox' value='" + response[i].carrier + "'/></td>" +
                            "<td><input type='textbox' value='" + response[i].premium + "'/></td>" +
                            "<td><input type='textbox' value='" + Annual.toFixed(2) + "'/></td>" +
                            "<td><input type='textbox' value='" + Montly.toFixed(2) + "'/></td></tr>";
                    }
                }
            }
            $('#tbody').html(tbody);
        },
        error: function () {
            $('#tbody').html(tbody);
        }
    })
}

