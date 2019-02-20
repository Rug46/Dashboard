// Hours Today Chart Variables
var activity_1 = $("#activity_1").val();
var activity_2 = $("#activity_2").val();
var activity_3 = $("#activity_3").val();
var activity_4 = $("#activity_4").val();
var activity_5 = $("#activity_5").val();
var activity_6 = $("#activity_6").val();
var activity_7 = $("#activity_7").val();
var activity_8 = $("#activity_8").val();
var activity_9 = $("#activity_9").val();
var activity_10 = $("#activity_10").val();
var activity_11 = $("#activity_11").val();
var activity_12 = $("#activity_12").val();
var activity_13 = $("#activity_13").val();
var activity_14 = $("#activity_14").val();
var activity_15 = $("#activity_15").val();
var activity_16 = $("#activity_16").val();
var activity_17 = $("#activity_17").val();
var activity_18 = $("#activity_18").val();
var activity_19 = $("#activity_19").val();
var activity_20 = $("#activity_20").val();
var activity_21 = $("#activity_21").val();
var activity_22 = $("#activity_22").val();
var activity_23 = $("#activity_23").val();
var activity_24 = $("#activity_24").val();

var activity_1l = $("#activity_1l").val();
var activity_2l = $("#activity_2l").val();
var activity_3l = $("#activity_3l").val();
var activity_4l = $("#activity_4l").val();
var activity_5l = $("#activity_5l").val();
var activity_6l = $("#activity_6l").val();
var activity_7l = $("#activity_7l").val();
var activity_8l = $("#activity_8l").val();
var activity_9l = $("#activity_9l").val();
var activity_10l = $("#activity_10l").val();
var activity_11l = $("#activity_11l").val();
var activity_12l = $("#activity_12l").val();
var activity_13l = $("#activity_13l").val();
var activity_14l = $("#activity_14l").val();
var activity_15l = $("#activity_15l").val();
var activity_16l = $("#activity_16l").val();
var activity_17l = $("#activity_17l").val();
var activity_18l = $("#activity_18l").val();
var activity_19l = $("#activity_19l").val();
var activity_20l = $("#activity_20l").val();
var activity_21l = $("#activity_21l").val();
var activity_22l = $("#activity_22l").val();
var activity_23l = $("#activity_23l").val();
var activity_24l = $("#activity_24l").val();

var activity_ctx = document.getElementById("gameChart").getContext('2d');
    var activity_chart = new Chart(activity_ctx, {
        // The type of chart we want to create
        type: 'line',
        // The data for our dataset
        data: {
            labels: [
                activity_24l,
                activity_23l,
                activity_22l,
                activity_21l,
                activity_20l,
                activity_19l,
                activity_18l,
                activity_17l,
                activity_16l,
                activity_15l,
                activity_14l,
                activity_13l,
                activity_12l,
                activity_11l,
                activity_10l,
                activity_9l,
                activity_8l,
                activity_7l,
                activity_6l,
                activity_5l,
                activity_4l,
                activity_3l,
                activity_2l,
                activity_1l
            ],
            datasets: [{
                label: 'Minutes',
                data: [
                    activity_24,
                    activity_23,
                    activity_22,
                    activity_21,
                    activity_20,
                    activity_19,
                    activity_18,
                    activity_17,
                    activity_16,
                    activity_15,
                    activity_14,
                    activity_13,
                    activity_12,
                    activity_11,
                    activity_10,
                    activity_9,
                    activity_8,
                    activity_7,
                    activity_6,
                    activity_5,
                    activity_4,
                    activity_3,
                    activity_2,
                    activity_1
                ],
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)'
            }]
        },
        // Configuration options go here
        options: {
            legend: {
                display: false
            },
            animation: {
                easing: "easeInOutBack"
            },
            scales: {
                yAxes: [{
                    display: !1,
                    ticks: {
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold",
                        beginAtZero: !0,
                        maxTicksLimit: 5,
                        padding: 0
                    },
                    gridLines: {
                        drawTicks: !1,
                        display: !1
                    }
                }],
                xAxes: [{
                    display: !1,
                    gridLines: {
                        zeroLineColor: "transparent"
                    },
                    ticks: {
                        padding: 0,
                        fontColor: "rgba(0,0,0,0.5)",
                        fontStyle: "bold"
                    }
                }]
            }
        }
});