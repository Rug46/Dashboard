// Hours Today Chart Variables
var hrt_d1 = $("#hrt_d1").val();
var hrt_d2 = $("#hrt_d2").val();
var hrt_d3 = $("#hrt_d3").val();
var hrt_d4 = $("#hrt_d4").val();
var hrt_d5 = $("#hrt_d5").val();
var hrt_d6 = $("#hrt_d6").val();
var hrt_d7 = $("#hrt_d7").val();
var hrt_d8 = $("#hrt_d8").val();
var hrt_d9 = $("#hrt_d9").val();
var hrt_d10 = $("#hrt_d10").val();
var hrt_d11 = $("#hrt_d11").val();
var hrt_d12 = $("#hrt_d12").val();
var hrt_d13 = $("#hrt_d13").val();
var hrt_d14 = $("#hrt_d14").val();
var hrt_d15 = $("#hrt_d15").val();
var hrt_d16 = $("#hrt_d16").val();
var hrt_d17 = $("#hrt_d17").val();
var hrt_d18 = $("#hrt_d18").val();
var hrt_d19 = $("#hrt_d19").val();
var hrt_d20 = $("#hrt_d20").val();
var hrt_d21 = $("#hrt_d21").val();
var hrt_d22 = $("#hrt_d22").val();
var hrt_d23 = $("#hrt_d23").val();
var hrt_d24 = $("#hrt_d24").val();

var hrt_d1l = $("#hrt_d1l").val();
var hrt_d2l = $("#hrt_d2l").val();
var hrt_d3l = $("#hrt_d3l").val();
var hrt_d4l = $("#hrt_d4l").val();
var hrt_d5l = $("#hrt_d5l").val();
var hrt_d6l = $("#hrt_d6l").val();
var hrt_d7l = $("#hrt_d7l").val();
var hrt_d8l = $("#hrt_d8l").val();
var hrt_d9l = $("#hrt_d9l").val();
var hrt_d10l = $("#hrt_d10l").val();
var hrt_d11l = $("#hrt_d11l").val();
var hrt_d12l = $("#hrt_d12l").val();
var hrt_d13l = $("#hrt_d13l").val();
var hrt_d14l = $("#hrt_d14l").val();
var hrt_d15l = $("#hrt_d15l").val();
var hrt_d16l = $("#hrt_d16l").val();
var hrt_d17l = $("#hrt_d17l").val();
var hrt_d18l = $("#hrt_d18l").val();
var hrt_d19l = $("#hrt_d19l").val();
var hrt_d20l = $("#hrt_d20l").val();
var hrt_d21l = $("#hrt_d21l").val();
var hrt_d22l = $("#hrt_d22l").val();
var hrt_d23l = $("#hrt_d23l").val();
var hrt_d24l = $("#hrt_d24l").val();

console.log(hrt_d1l);

var hrt_ctx = document.getElementById("hours_today").getContext('2d');
    var hrt_chart = new Chart(hrt_ctx, {
        // The type of chart we want to create
        type: 'line',
        // The data for our dataset
        data: {
            labels: [
                hrt_d24l,
                hrt_d23l,
                hrt_d22l,
                hrt_d21l,
                hrt_d20l,
                hrt_d19l,
                hrt_d18l,
                hrt_d17l,
                hrt_d16l,
                hrt_d15l,
                hrt_d14l,
                hrt_d13l,
                hrt_d12l,
                hrt_d11l,
                hrt_d10l,
                hrt_d9l,
                hrt_d8l,
                hrt_d7l,
                hrt_d6l,
                hrt_d5l,
                hrt_d4l,
                hrt_d3l,
                hrt_d2l,
                hrt_d1l
            ],
            datasets: [{
                label: 'Minutes',
                data: [
                    hrt_d24,
                    hrt_d23,
                    hrt_d22,
                    hrt_d21,
                    hrt_d20,
                    hrt_d19,
                    hrt_d18,
                    hrt_d17,
                    hrt_d16,
                    hrt_d15,
                    hrt_d14,
                    hrt_d13,
                    hrt_d12,
                    hrt_d11,
                    hrt_d10,
                    hrt_d9,
                    hrt_d8,
                    hrt_d7,
                    hrt_d6,
                    hrt_d5,
                    hrt_d4,
                    hrt_d3,
                    hrt_d2,
                    hrt_d1
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
var hrt_w1 = $("#hrt_w1").val();
var hrt_w2 = $("#hrt_w2").val();
var hrt_w3 = $("#hrt_w3").val();
var hrt_w4 = $("#hrt_w4").val();
var hrt_w5 = $("#hrt_w5").val();
var hrt_w6 = $("#hrt_w6").val();
var hrt_w7 = $("#hrt_w7").val();

var hrt_w1l = $("#hrt_w1l").val();
var hrt_w2l = $("#hrt_w2l").val();
var hrt_w3l = $("#hrt_w3l").val();
var hrt_w4l = $("#hrt_w4l").val();
var hrt_w5l = $("#hrt_w5l").val();
var hrt_w6l = $("#hrt_w6l").val();
var hrt_w7l = $("#hrt_w7l").val();

var hrw_ctx = document.getElementById("hours_week").getContext('2d');
var hrw_chart = new Chart(hrw_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [hrt_w7l, hrt_w6l, hrt_w5l, hrt_w4l, hrt_w3l, hrt_w2l, hrt_w1l],
        datasets: [{
            label: 'Minutes',
            data: [hrt_w7, hrt_w6, hrt_w5, hrt_w4, hrt_w3, hrt_w2, hrt_w1],
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
var hrt_m1 = $("#hrt_m1").val();
var hrt_m2 = $("#hrt_m2").val();
var hrt_m3 = $("#hrt_m3").val();
var hrt_m4 = $("#hrt_m4").val();
var hrt_m5 = $("#hrt_m5").val();
var hrt_m6 = $("#hrt_m6").val();
var hrt_m7 = $("#hrt_m7").val();
var hrt_m8 = $("#hrt_m8").val();
var hrt_m9 = $("#hrt_m9").val();
var hrt_m10 = $("#hrt_m10").val();
var hrt_m11 = $("#hrt_m11").val();
var hrt_m12 = $("#hrt_m12").val();
var hrt_m13 = $("#hrt_m13").val();
var hrt_m14 = $("#hrt_m14").val();
var hrt_m15 = $("#hrt_m15").val();
var hrt_m16 = $("#hrt_m16").val();
var hrt_m17 = $("#hrt_m17").val();
var hrt_m18 = $("#hrt_m18").val();
var hrt_m19 = $("#hrt_m19").val();
var hrt_m20 = $("#hrt_m20").val();
var hrt_m21 = $("#hrt_m21").val();
var hrt_m22 = $("#hrt_m22").val();
var hrt_m23 = $("#hrt_m23").val();
var hrt_m24 = $("#hrt_m24").val();
var hrt_m25 = $("#hrt_m25").val();
var hrt_m26 = $("#hrt_m26").val();
var hrt_m27 = $("#hrt_m27").val();
var hrt_m28 = $("#hrt_m28").val();

var hrt_m1l = $("#hrt_m1l").val();
var hrt_m2l = $("#hrt_m2l").val();
var hrt_m3l = $("#hrt_m3l").val();
var hrt_m4l = $("#hrt_m4l").val();
var hrt_m5l = $("#hrt_m5l").val();
var hrt_m6l = $("#hrt_m6l").val();
var hrt_m7l = $("#hrt_m7l").val();
var hrt_m8l = $("#hrt_m8l").val();
var hrt_m9l = $("#hrt_m9l").val();
var hrt_m10l = $("#hrt_m10l").val();
var hrt_m11l = $("#hrt_m11l").val();
var hrt_m12l = $("#hrt_m12l").val();
var hrt_m13l = $("#hrt_m13l").val();
var hrt_m14l = $("#hrt_m14l").val();
var hrt_m15l = $("#hrt_m15l").val();
var hrt_m16l = $("#hrt_m16l").val();
var hrt_m17l = $("#hrt_m17l").val();
var hrt_m18l = $("#hrt_m18l").val();
var hrt_m19l = $("#hrt_m19l").val();
var hrt_m20l = $("#hrt_m20l").val();
var hrt_m21l = $("#hrt_m21l").val();
var hrt_m22l = $("#hrt_m22l").val();
var hrt_m23l = $("#hrt_m23l").val();
var hrt_m24l = $("#hrt_m24l").val();
var hrt_m25l = $("#hrt_m25l").val();
var hrt_m26l = $("#hrt_m26l").val();
var hrt_m27l = $("#hrt_m27l").val();
var hrt_m28l = $("#hrt_m28l").val();

var hrm_ctx = document.getElementById("hours_month").getContext('2d');
var hrm_chart = new Chart(hrm_ctx, {
    // The type of chart we want to create
    type: 'line',
    // The data for our dataset
    data: {
        labels: [
            hrt_m28l,
            hrt_m27l,
            hrt_m26l,
            hrt_m25l,
            hrt_m24l,
            hrt_m23l,
            hrt_m22l,
            hrt_m21l,
            hrt_m20l,
            hrt_m19l,
            hrt_m18l,
            hrt_m17l,
            hrt_m16l,
            hrt_m15l,
            hrt_m14l,
            hrt_m13l,
            hrt_m12l,
            hrt_m11l,
            hrt_m10l,
            hrt_m9l,
            hrt_m8l,
            hrt_m7l,
            hrt_m6l,
            hrt_m5l,
            hrt_m4l,
            hrt_m3l,
            hrt_m2l,
            hrt_m1l
        ],
        datasets: [{
            label: 'Minutes',
            data: [
                hrt_m28,
                hrt_m27,
                hrt_m26,
                hrt_m25,
                hrt_m24,
                hrt_m23,
                hrt_m22,
                hrt_m21,
                hrt_m20,
                hrt_m19,
                hrt_m18,
                hrt_m17,
                hrt_m16,
                hrt_m15,
                hrt_m14,
                hrt_m13,
                hrt_m12,
                hrt_m11,
                hrt_m10,
                hrt_m9,
                hrt_m8,
                hrt_m7,
                hrt_m6,
                hrt_m5,
                hrt_m4,
                hrt_m3,
                hrt_m2,
                hrt_m1
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
var gp_g1 = $("#gp_g1").val();
var gp_g2 = $("#gp_g2").val();
var gp_g3 = $("#gp_g3").val();
var gp_g4 = $("#gp_g4").val();
var gp_g5 = $("#gp_g5").val();

var gp_l1 = $("#gp_l1").val();
var gp_l2 = $("#gp_l2").val();
var gp_l3 = $("#gp_l3").val();
var gp_l4 = $("#gp_l4").val();
var gp_l5 = $("#gp_l5").val();

var gp_ctx = document.getElementById("games_played").getContext('2d');
var gp_chart = new Chart(gp_ctx, {
    type: 'doughnut',
    data: {
        labels: [gp_l1, gp_l2, gp_l3, gp_l4, gp_l5],
        datasets: [{
            label: 'Minutes',
            data: [gp_g1, gp_g2, gp_g3, gp_g4, gp_g5],
            backgroundColor: ["#4286f4", "#f45041", "#f4bb41", "#61f441", "#e541f4"],
            borderColor: '#ffffff',
        }]
    },
    options: {

    }
})