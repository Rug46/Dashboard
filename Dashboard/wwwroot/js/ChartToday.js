// Hours Today Chart Variables
var activity_d1 = document.getElementById("activity_d1").value;
var activity_d2 = document.getElementById("activity_d2").value;
var activity_d3 = document.getElementById("activity_d3").value;
var activity_d4 = document.getElementById("activity_d4").value;
var activity_d5 = document.getElementById("activity_d5").value;
var activity_d6 = document.getElementById("activity_d6").value;
var activity_d7 = document.getElementById("activity_d7").value;
var activity_d8 = document.getElementById("activity_d8").value;
var activity_d9 = document.getElementById("activity_d9").value;
var activity_d10 = document.getElementById("activity_d10").value;
var activity_d11 = document.getElementById("activity_d11").value;
var activity_d12 = document.getElementById("activity_d12").value;
var activity_d13 = document.getElementById("activity_d13").value;
var activity_d14 = document.getElementById("activity_d14").value;
var activity_d15 = document.getElementById("activity_d15").value;
var activity_d16 = document.getElementById("activity_d16").value;
var activity_d17 = document.getElementById("activity_d17").value;
var activity_d18 = document.getElementById("activity_d18").value;
var activity_d19 = document.getElementById("activity_d19").value;
var activity_d20 = document.getElementById("activity_d20").value;
var activity_d21 = document.getElementById("activity_d21").value;
var activity_d22 = document.getElementById("activity_d22").value;
var activity_d23 = document.getElementById("activity_d23").value;
var activity_d24 = document.getElementById("activity_d24").value;

var activity_d1l = document.getElementById("activity_d1l").value;
var activity_d2l = document.getElementById("activity_d2l").value;
var activity_d3l = document.getElementById("activity_d3l").value;
var activity_d4l = document.getElementById("activity_d4l").value;
var activity_d5l = document.getElementById("activity_d5l").value;
var activity_d6l = document.getElementById("activity_d6l").value;
var activity_d7l = document.getElementById("activity_d7l").value;
var activity_d8l = document.getElementById("activity_d8l").value;
var activity_d9l = document.getElementById("activity_d9l").value;
var activity_d10l = document.getElementById("activity_d10l").value;
var activity_d11l = document.getElementById("activity_d11l").value;
var activity_d12l = document.getElementById("activity_d12l").value;
var activity_d13l = document.getElementById("activity_d13l").value;
var activity_d14l = document.getElementById("activity_d14l").value;
var activity_d15l = document.getElementById("activity_d15l").value;
var activity_d16l = document.getElementById("activity_d16l").value;
var activity_d17l = document.getElementById("activity_d17l").value;
var activity_d18l = document.getElementById("activity_d18l").value;
var activity_d19l = document.getElementById("activity_d19l").value;
var activity_d20l = document.getElementById("activity_d20l").value;
var activity_d21l = document.getElementById("activity_d21l").value;
var activity_d22l = document.getElementById("activity_d22l").value;
var activity_d23l = document.getElementById("activity_d23l").value;
var activity_d24l = document.getElementById("activity_d24l").value;

console.log(activity_d1l);

var activity_ctx = document.getElementById("hours_today").getContext('2d');
var activity_chart = new Chart(activity_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [
            activity_d24l,
            activity_d23l,
            activity_d22l,
            activity_d21l,
            activity_d20l,
            activity_d19l,
            activity_d18l,
            activity_d17l,
            activity_d16l,
            activity_d15l,
            activity_d14l,
            activity_d13l,
            activity_d12l,
            activity_d11l,
            activity_d10l,
            activity_d9l,
            activity_d8l,
            activity_d7l,
            activity_d6l,
            activity_d5l,
            activity_d4l,
            activity_d3l,
            activity_d2l,
            activity_d1l
        ],
        datasets: [{
            label: 'Minutes',
            data: [
                activity_d24,
                activity_d23,
                activity_d22,
                activity_d21,
                activity_d20,
                activity_d19,
                activity_d18,
                activity_d17,
                activity_d16,
                activity_d15,
                activity_d14,
                activity_d13,
                activity_d12,
                activity_d11,
                activity_d10,
                activity_d9,
                activity_d8,
                activity_d7,
                activity_d6,
                activity_d5,
                activity_d4,
                activity_d3,
                activity_d2,
                activity_d1
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