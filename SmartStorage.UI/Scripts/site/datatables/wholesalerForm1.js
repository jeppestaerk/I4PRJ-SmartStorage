﻿$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var fromDate = $("#fromdate").datepicker("getDate");
        var toDate = $("#todate").datepicker("getDate");
        var updatedDate = data[7]; // use data for the hidden "updated" column
        if (fromDate.getTime() === null || toDate.getTime() === null)
            return true;

        console.log("hej");
        //console.log(updatedDate);
        //console.log(fromDate);
        //console.log("updatedDate: " + updatedDate + " " + updatedDate);
        //console.log("fromdate: " + fromDate.toLocaleDateString('da-DK') + " " + fromDate.getTime());
        //console.log("todate: " + toDate.toLocaleDateString('da-DK') + " " + toDate.getTime());


        if (isNaN(fromDate.getTime()) && isNaN(toDate.getTime()) ||
             isNaN(fromDate.getTime()) && updatedDate <= toDate.getTime() ||
             fromDate.getTime() <= updatedDate && isNaN(toDate.getTime()) ||
             fromDate.getTime() <= updatedDate && updatedDate <= toDate.getTime()) {
            return true;
        }
        return false;
    }
);


$(document)
    .ready(function () {
        $("#wholesalers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/wholesalers/getwholesalertransactions",
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "product.wholesaler.name"
                    },
                    {
                        data: "transactionId"
                    },
                    {
                        data: "product.name"
                    },
                    {
                        data: "quantity"
                    },
                    {
                        data: "updated",
                        render: function (data) {
                            var date = new Date(data).toLocaleDateString('da-DK');
                            return date;
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "product.wholesaler.wholesalerId",
                        "visible": false
                    },
                    {
                       data: "updated",
                       render: function(data) {
                       var date = new Date(data);
                       return date.getTime();
                       },
                       "visible": false
                    }
                    ]
            });
        var table = $("#wholesalers-table").DataTable();

        $("#Wholesaler_WholesalerId").on("change", function () {
            table.columns(6).search(this.value).draw();
        });

        


        $('#fromdate').datepicker({
            dataFormat: "dd-mm-yy",
            defaultDate: '-1m+1d',
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true,
            onSelect: function (selectedDate) {
                $("#todate").datepicker("option", "minDate", selectedDate);
            }
        });
        $('#todate').datepicker({
            dataFormat: "dd-mm-yy",
            maxDate: +1,
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true,
            onSelect: function (selectedDate) {
                $("#fromdate").datepicker("option", "maxDate", selectedDate);
            }
        });

        $('#fromIcon').click(function () { $('#fromdate').datepicker('show'); });

        $('#toIcon').click(function () { $('#todate').datepicker('show'); });

        $('#filter')
            .click(
                function displayDate() {
                    table.draw();
                });
        

    });