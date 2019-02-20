var year_ctx = document.getElementById("monthChart").getContext('2d');
var year_chart = new Chart(year_ctx, {
    type: 'line',
    data: {
        labels: [
            document.getElementById("activity_1l").value,
            document.getElementById("activity_2l").value,
            document.getElementById("activity_3l").value,
            document.getElementById("activity_4l").value,
            document.getElementById("activity_5l").value,
            document.getElementById("activity_6l").value,
            document.getElementById("activity_7l").value,
            document.getElementById("activity_8l").value,
            document.getElementById("activity_9l").value,
            document.getElementById("activity_10l").value,
            document.getElementById("activity_11l").value,
            document.getElementById("activity_12l").value,
            document.getElementById("activity_13l").value,
            document.getElementById("activity_14l").value,
            document.getElementById("activity_15l").value,
            document.getElementById("activity_16l").value,
            document.getElementById("activity_17l").value,
            document.getElementById("activity_18l").value,
            document.getElementById("activity_19l").value,
            document.getElementById("activity_20l").value,
            document.getElementById("activity_21l").value,
            document.getElementById("activity_22l").value,
            document.getElementById("activity_23l").value,
            document.getElementById("activity_24l").value,
            document.getElementById("activity_25l").value,
            document.getElementById("activity_26l").value,
            document.getElementById("activity_27l").value,
            document.getElementById("activity_28l").value,
            document.getElementById("activity_29l").value,
            document.getElementById("activity_30l").value,
            document.getElementById("activity_31l").value
        ],
        datasets: [{
            label: 'Minutes',
            data: [
                document.getElementById("activity_1").value,
                document.getElementById("activity_2").value,
                document.getElementById("activity_3").value,
                document.getElementById("activity_4").value,
                document.getElementById("activity_5").value,
                document.getElementById("activity_6").value,
                document.getElementById("activity_7").value,
                document.getElementById("activity_8").value,
                document.getElementById("activity_9").value,
                document.getElementById("activity_10").value,
                document.getElementById("activity_11").value,
                document.getElementById("activity_12").value,
                document.getElementById("activity_13").value,
                document.getElementById("activity_14").value,
                document.getElementById("activity_15").value,
                document.getElementById("activity_16").value,
                document.getElementById("activity_17").value,
                document.getElementById("activity_18").value,
                document.getElementById("activity_19").value,
                document.getElementById("activity_20").value,
                document.getElementById("activity_21").value,
                document.getElementById("activity_22").value,
                document.getElementById("activity_23").value,
                document.getElementById("activity_24").value,
                document.getElementById("activity_25").value,
                document.getElementById("activity_26").value,
                document.getElementById("activity_27").value,
                document.getElementById("activity_28").value,
                document.getElementById("activity_29").value,
                document.getElementById("activity_30").value,
                document.getElementById("activity_31").value
            ],
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1'
        }]
    },
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
                    fontColor: "rgba(0, 0, 0, 0.5)",
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
                    fontColor: "rgba(0, 0, 0, 0.5)",
                    fontStyle: "bold"
                }
            }]
        }
    }
});