// Hours Month Chart Variables
var activity_m1 = document.getElementById("activity_m1").value;
var activity_m2 = document.getElementById("activity_m2").value;
var activity_m3 = document.getElementById("activity_m3").value;
var activity_m4 = document.getElementById("activity_m4").value;
var activity_m5 = document.getElementById("activity_m5").value;
var activity_m6 = document.getElementById("activity_m6").value;
var activity_m7 = document.getElementById("activity_m7").value;
var activity_m8 = document.getElementById("activity_m8").value;
var activity_m9 = document.getElementById("activity_m9").value;
var activity_m10 = document.getElementById("activity_m10").value;
var activity_m11 = document.getElementById("activity_m11").value;
var activity_m12 = document.getElementById("activity_m12").value;
var activity_m13 = document.getElementById("activity_m13").value;
var activity_m14 = document.getElementById("activity_m14").value;
var activity_m15 = document.getElementById("activity_m15").value;
var activity_m16 = document.getElementById("activity_m16").value;
var activity_m17 = document.getElementById("activity_m17").value;
var activity_m18 = document.getElementById("activity_m18").value;
var activity_m19 = document.getElementById("activity_m19").value;
var activity_m20 = document.getElementById("activity_m20").value;
var activity_m21 = document.getElementById("activity_m21").value;
var activity_m22 = document.getElementById("activity_m22").value;
var activity_m23 = document.getElementById("activity_m23").value;
var activity_m24 = document.getElementById("activity_m24").value;
var activity_m25 = document.getElementById("activity_m25").value;
var activity_m26 = document.getElementById("activity_m26").value;
var activity_m27 = document.getElementById("activity_m27").value;
var activity_m28 = document.getElementById("activity_m28").value;

var activity_m1l = document.getElementById("activity_m1l").value;
var activity_m2l = document.getElementById("activity_m2l").value;
var activity_m3l = document.getElementById("activity_m3l").value;
var activity_m4l = document.getElementById("activity_m4l").value;
var activity_m5l = document.getElementById("activity_m5l").value;
var activity_m6l = document.getElementById("activity_m6l").value;
var activity_m7l = document.getElementById("activity_m7l").value;
var activity_m8l = document.getElementById("activity_m8l").value;
var activity_m9l = document.getElementById("activity_m9l").value;
var activity_m10l = document.getElementById("activity_m10l").value;
var activity_m11l = document.getElementById("activity_m11l").value;
var activity_m12l = document.getElementById("activity_m12l").value;
var activity_m13l = document.getElementById("activity_m13l").value;
var activity_m14l = document.getElementById("activity_m14l").value;
var activity_m15l = document.getElementById("activity_m15l").value;
var activity_m16l = document.getElementById("activity_m16l").value;
var activity_m17l = document.getElementById("activity_m17l").value;
var activity_m18l = document.getElementById("activity_m18l").value;
var activity_m19l = document.getElementById("activity_m19l").value;
var activity_m20l = document.getElementById("activity_m20l").value;
var activity_m21l = document.getElementById("activity_m21l").value;
var activity_m22l = document.getElementById("activity_m22l").value;
var activity_m23l = document.getElementById("activity_m23l").value;
var activity_m24l = document.getElementById("activity_m24l").value;
var activity_m25l = document.getElementById("activity_m25l").value;
var activity_m26l = document.getElementById("activity_m26l").value;
var activity_m27l = document.getElementById("activity_m27l").value;
var activity_m28l = document.getElementById("activity_m28l").value;

var hrm_ctx = document.getElementById("hours_month").getContext('2d');
var hrm_chart = new Chart(hrm_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [
            activity_m28l,
            activity_m27l,
            activity_m26l,
            activity_m25l,
            activity_m24l,
            activity_m23l,
            activity_m22l,
            activity_m21l,
            activity_m20l,
            activity_m19l,
            activity_m18l,
            activity_m17l,
            activity_m16l,
            activity_m15l,
            activity_m14l,
            activity_m13l,
            activity_m12l,
            activity_m11l,
            activity_m10l,
            activity_m9l,
            activity_m8l,
            activity_m7l,
            activity_m6l,
            activity_m5l,
            activity_m4l,
            activity_m3l,
            activity_m2l,
            activity_m1l
        ],
        datasets: [{
            label: 'Minutes',
            data: [
                activity_m28,
                activity_m27,
                activity_m26,
                activity_m25,
                activity_m24,
                activity_m23,
                activity_m22,
                activity_m21,
                activity_m20,
                activity_m19,
                activity_m18,
                activity_m17,
                activity_m16,
                activity_m15,
                activity_m14,
                activity_m13,
                activity_m12,
                activity_m11,
                activity_m10,
                activity_m9,
                activity_m8,
                activity_m7,
                activity_m6,
                activity_m5,
                activity_m4,
                activity_m3,
                activity_m2,
                activity_m1
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