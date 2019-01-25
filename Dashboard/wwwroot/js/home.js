// Hours Today Chart Variables
var activity_d1 = $("#activity_d1").val();
var activity_d2 = $("#activity_d2").val();
var activity_d3 = $("#activity_d3").val();
var activity_d4 = $("#activity_d4").val();
var activity_d5 = $("#activity_d5").val();
var activity_d6 = $("#activity_d6").val();
var activity_d7 = $("#activity_d7").val();
var activity_d8 = $("#activity_d8").val();
var activity_d9 = $("#activity_d9").val();
var activity_d10 = $("#activity_d10").val();
var activity_d11 = $("#activity_d11").val();
var activity_d12 = $("#activity_d12").val();
var activity_d13 = $("#activity_d13").val();
var activity_d14 = $("#activity_d14").val();
var activity_d15 = $("#activity_d15").val();
var activity_d16 = $("#activity_d16").val();
var activity_d17 = $("#activity_d17").val();
var activity_d18 = $("#activity_d18").val();
var activity_d19 = $("#activity_d19").val();
var activity_d20 = $("#activity_d20").val();
var activity_d21 = $("#activity_d21").val();
var activity_d22 = $("#activity_d22").val();
var activity_d23 = $("#activity_d23").val();
var activity_d24 = $("#activity_d24").val();

var activity_d1l = $("#activity_d1l").val();
var activity_d2l = $("#activity_d2l").val();
var activity_d3l = $("#activity_d3l").val();
var activity_d4l = $("#activity_d4l").val();
var activity_d5l = $("#activity_d5l").val();
var activity_d6l = $("#activity_d6l").val();
var activity_d7l = $("#activity_d7l").val();
var activity_d8l = $("#activity_d8l").val();
var activity_d9l = $("#activity_d9l").val();
var activity_d10l = $("#activity_d10l").val();
var activity_d11l = $("#activity_d11l").val();
var activity_d12l = $("#activity_d12l").val();
var activity_d13l = $("#activity_d13l").val();
var activity_d14l = $("#activity_d14l").val();
var activity_d15l = $("#activity_d15l").val();
var activity_d16l = $("#activity_d16l").val();
var activity_d17l = $("#activity_d17l").val();
var activity_d18l = $("#activity_d18l").val();
var activity_d19l = $("#activity_d19l").val();
var activity_d20l = $("#activity_d20l").val();
var activity_d21l = $("#activity_d21l").val();
var activity_d22l = $("#activity_d22l").val();
var activity_d23l = $("#activity_d23l").val();
var activity_d24l = $("#activity_d24l").val();

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

// Hours Week Chart Variables
var activity_w1 = $("#activity_w1").val();
var activity_w2 = $("#activity_w2").val();
var activity_w3 = $("#activity_w3").val();
var activity_w4 = $("#activity_w4").val();
var activity_w5 = $("#activity_w5").val();
var activity_w6 = $("#activity_w6").val();
var activity_w7 = $("#activity_w7").val();

var activity_w1l = $("#activity_w1l").val();
var activity_w2l = $("#activity_w2l").val();
var activity_w3l = $("#activity_w3l").val();
var activity_w4l = $("#activity_w4l").val();
var activity_w5l = $("#activity_w5l").val();
var activity_w6l = $("#activity_w6l").val();
var activity_w7l = $("#activity_w7l").val();

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

// Hours Month Chart Variables
var activity_m1 = $("#activity_m1").val();
var activity_m2 = $("#activity_m2").val();
var activity_m3 = $("#activity_m3").val();
var activity_m4 = $("#activity_m4").val();
var activity_m5 = $("#activity_m5").val();
var activity_m6 = $("#activity_m6").val();
var activity_m7 = $("#activity_m7").val();
var activity_m8 = $("#activity_m8").val();
var activity_m9 = $("#activity_m9").val();
var activity_m10 = $("#activity_m10").val();
var activity_m11 = $("#activity_m11").val();
var activity_m12 = $("#activity_m12").val();
var activity_m13 = $("#activity_m13").val();
var activity_m14 = $("#activity_m14").val();
var activity_m15 = $("#activity_m15").val();
var activity_m16 = $("#activity_m16").val();
var activity_m17 = $("#activity_m17").val();
var activity_m18 = $("#activity_m18").val();
var activity_m19 = $("#activity_m19").val();
var activity_m20 = $("#activity_m20").val();
var activity_m21 = $("#activity_m21").val();
var activity_m22 = $("#activity_m22").val();
var activity_m23 = $("#activity_m23").val();
var activity_m24 = $("#activity_m24").val();
var activity_m25 = $("#activity_m25").val();
var activity_m26 = $("#activity_m26").val();
var activity_m27 = $("#activity_m27").val();
var activity_m28 = $("#activity_m28").val();

var activity_m1l = $("#activity_m1l").val();
var activity_m2l = $("#activity_m2l").val();
var activity_m3l = $("#activity_m3l").val();
var activity_m4l = $("#activity_m4l").val();
var activity_m5l = $("#activity_m5l").val();
var activity_m6l = $("#activity_m6l").val();
var activity_m7l = $("#activity_m7l").val();
var activity_m8l = $("#activity_m8l").val();
var activity_m9l = $("#activity_m9l").val();
var activity_m10l = $("#activity_m10l").val();
var activity_m11l = $("#activity_m11l").val();
var activity_m12l = $("#activity_m12l").val();
var activity_m13l = $("#activity_m13l").val();
var activity_m14l = $("#activity_m14l").val();
var activity_m15l = $("#activity_m15l").val();
var activity_m16l = $("#activity_m16l").val();
var activity_m17l = $("#activity_m17l").val();
var activity_m18l = $("#activity_m18l").val();
var activity_m19l = $("#activity_m19l").val();
var activity_m20l = $("#activity_m20l").val();
var activity_m21l = $("#activity_m21l").val();
var activity_m22l = $("#activity_m22l").val();
var activity_m23l = $("#activity_m23l").val();
var activity_m24l = $("#activity_m24l").val();
var activity_m25l = $("#activity_m25l").val();
var activity_m26l = $("#activity_m26l").val();
var activity_m27l = $("#activity_m27l").val();
var activity_m28l = $("#activity_m28l").val();

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

// Pie Chart Data
var gamesPlayed_g1 = $("#gamesPlayed_g1").val();
var gamesPlayed_g2 = $("#gamesPlayed_g2").val();
var gamesPlayed_g3 = $("#gamesPlayed_g3").val();
var gamesPlayed_g4 = $("#gamesPlayed_g4").val();
var gamesPlayed_g5 = $("#gamesPlayed_g5").val();

var gamesPlayed_l1 = $("#gamesPlayed_l1").val();
var gamesPlayed_l2 = $("#gamesPlayed_l2").val();
var gamesPlayed_l3 = $("#gamesPlayed_l3").val();
var gamesPlayed_l4 = $("#gamesPlayed_l4").val();
var gamesPlayed_l5 = $("#gamesPlayed_l5").val();

var gamesPlayed_ctx = document.getElementById("games_played").getContext('2d');
var gamesPlayed_chart = new Chart(gamesPlayed_ctx, {
    type: 'doughnut',
    data: {
        labels: [gamesPlayed_l1, gamesPlayed_l2, gamesPlayed_l3, gamesPlayed_l4, gamesPlayed_l5],
        datasets: [{
            label: 'Minutes',
            data: [gamesPlayed_g1, gamesPlayed_g2, gamesPlayed_g3, gamesPlayed_g4, gamesPlayed_g5],
            backgroundColor: ["#4286f4", "#f45041", "#f4bb41", "#61f441", "#e541f4"],
            borderColor: '#ffffff',
        }]
    },
    options: {

    }
})