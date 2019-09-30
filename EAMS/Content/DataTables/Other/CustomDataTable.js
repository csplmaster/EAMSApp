/* Load Data In Table */
function LoadJDT(TableId)
{
    $(document).ready(function () {
        oTable = $('#' + TableId).DataTable({
            "scrollX": true,
            "processing": true
            //"serverSide": true
        });
    });
}

/* Perform Delete Operation in Jquery Datatable */
function DeleteJDTRow(id, event, TableId, Jsonurl) {
    if (confirm("Are you sure you want to delete this record...?")) {
        //var row = $(this).closest("tr");
        oTable = $('#' + TableId).DataTable();
        //var parent = $(this).parent('td').parent('tr');
        var parent = $(event).parents('tr');
        $.ajax({
            type: "POST",
            url: Jsonurl,
            data: '{id: ' + id + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data == "Deleted") {
                    alert("Record Deleted !");
                    $('#' + TableId).DataTable().row(parent).remove().draw(false);
                }
                else {
                    alert("Something Went Wrong!");
                }
            }
        });
    }
};

/* Get Date and Time (add datetime at the end of download file) in Jquery Datatable */
function getDateTime() {
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    var hour = now.getHours();
    var minute = now.getMinutes();
    var second = now.getSeconds();
    if (month.toString().length == 1) {
        month = '0' + month;
    }
    if (day.toString().length == 1) {
        day = '0' + day;
    }
    if (hour.toString().length == 1) {
        hour = '0' + hour;
    }
    if (minute.toString().length == 1) {
        minute = '0' + minute;
    }
    if (second.toString().length == 1) {
        second = '0' + second;
    }
    var dateTime = year + '-' + month + '-' + day + '_' + hour + ':' + minute + ':' + second;
    return dateTime;
}
