var activity_00 = document.getElementById("activity_00").value;
var activity_01 = document.getElementById("activity_01").value;
var activity_02 = document.getElementById("activity_02").value;
var activity_03 = document.getElementById("activity_03").value;
var activity_04 = document.getElementById("activity_04").value;
var activity_05 = document.getElementById("activity_05").value;
var activity_06 = document.getElementById("activity_06").value;
var activity_07 = document.getElementById("activity_07").value;
var activity_08 = document.getElementById("activity_08").value;
var activity_09 = document.getElementById("activity_09").value;
var activity_10 = document.getElementById("activity_10").value;
var activity_11 = document.getElementById("activity_11").value;
var activity_12 = document.getElementById("activity_12").value;
var activity_13 = document.getElementById("activity_13").value;
var activity_14 = document.getElementById("activity_14").value;
var activity_15 = document.getElementById("activity_15").value;
var activity_16 = document.getElementById("activity_16").value;
var activity_17 = document.getElementById("activity_17").value;
var activity_18 = document.getElementById("activity_18").value;
var activity_19 = document.getElementById("activity_19").value;
var activity_20 = document.getElementById("activity_20").value;
var activity_21 = document.getElementById("activity_21").value;
var activity_22 = document.getElementById("activity_22").value;
var activity_23 = document.getElementById("activity_23").value;

var activity_00l = document.getElementById("activity_00l").value;
var activity_01l = document.getElementById("activity_01l").value;
var activity_02l = document.getElementById("activity_02l").value;
var activity_03l = document.getElementById("activity_03l").value;
var activity_04l = document.getElementById("activity_04l").value;
var activity_05l = document.getElementById("activity_05l").value;
var activity_06l = document.getElementById("activity_06l").value;
var activity_07l = document.getElementById("activity_07l").value;
var activity_08l = document.getElementById("activity_08l").value;
var activity_09l = document.getElementById("activity_09l").value;
var activity_10l = document.getElementById("activity_10l").value;
var activity_11l = document.getElementById("activity_11l").value;
var activity_12l = document.getElementById("activity_12l").value;
var activity_13l = document.getElementById("activity_13l").value;
var activity_14l = document.getElementById("activity_14l").value;
var activity_15l = document.getElementById("activity_15l").value;
var activity_16l = document.getElementById("activity_16l").value;
var activity_17l = document.getElementById("activity_17l").value;
var activity_18l = document.getElementById("activity_18l").value;
var activity_19l = document.getElementById("activity_19l").value;
var activity_20l = document.getElementById("activity_20l").value;
var activity_21l = document.getElementById("activity_21l").value;
var activity_22l = document.getElementById("activity_22l").value;
var activity_23l = document.getElementById("activity_23l").value;

console.log(activity_10);
console.log(activity_10l);

var act_ctx = document.getElementById("hour_chart").getContext('2d');
var act_chart = new Chart(act_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [
            activity_00l,
            activity_01l,
            activity_02l,
            activity_03l,
            activity_04l,
            activity_05l,
            activity_06l,
            activity_07l,
            activity_08l,
            activity_09l,
            activity_10l,
            activity_11l,
            activity_12l,
            activity_13l,
            activity_14l,
            activity_15l,
            activity_16l,
            activity_17l,
            activity_18l,
            activity_19l,
            activity_20l,
            activity_21l,
            activity_22l,
            activity_23l
        ],
        datasets: [{
            label: 'Minutes',
            data: [
                activity_00,
                activity_01,
                activity_02,
                activity_03,
                activity_04,
                activity_05,
                activity_06,
                activity_07,
                activity_08,
                activity_09,
                activity_10,
                activity_11,
                activity_12,
                activity_13,
                activity_14,
                activity_15,
                activity_16,
                activity_17,
                activity_18,
                activity_19,
                activity_20,
                activity_21,
                activity_22,
                activity_23
            ],
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
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