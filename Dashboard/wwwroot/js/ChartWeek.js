// Hours Week Chart Variables
var activity_w1 = document.getElementById("activity_w1").value;
var activity_w2 = document.getElementById("activity_w2").value;
var activity_w3 = document.getElementById("activity_w3").value;
var activity_w4 = document.getElementById("activity_w4").value;
var activity_w5 = document.getElementById("activity_w5").value;
var activity_w6 = document.getElementById("activity_w6").value;
var activity_w7 = document.getElementById("activity_w7").value;

var activity_w1l = document.getElementById("activity_w1l").value;
var activity_w2l = document.getElementById("activity_w2l").value;
var activity_w3l = document.getElementById("activity_w3l").value;
var activity_w4l = document.getElementById("activity_w4l").value;
var activity_w5l = document.getElementById("activity_w5l").value;
var activity_w6l = document.getElementById("activity_w6l").value;
var activity_w7l = document.getElementById("activity_w7l").value;

var hrw_ctx = document.getElementById("hours_week").getContext('2d');
var hrw_chart = new Chart(hrw_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [activity_w7l, activity_w6l, activity_w5l, activity_w4l, activity_w3l, activity_w2l, activity_w1l],
        datasets: [{
            label: 'Minutes',
            data: [activity_w7, activity_w6, activity_w5, activity_w4, activity_w3, activity_w2, activity_w1],
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