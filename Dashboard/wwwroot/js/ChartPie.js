// Pie Chart Data
var gamesPlayed_g1 = document.getElementById("gamesPlayed_g1").value;
var gamesPlayed_g2 = document.getElementById("gamesPlayed_g2").value;
var gamesPlayed_g3 = document.getElementById("gamesPlayed_g3").value;
var gamesPlayed_g4 = document.getElementById("gamesPlayed_g4").value;
var gamesPlayed_g5 = document.getElementById("gamesPlayed_g5").value;

var gamesPlayed_l1 = document.getElementById("gamesPlayed_l1").value;
var gamesPlayed_l2 = document.getElementById("gamesPlayed_l2").value;
var gamesPlayed_l3 = document.getElementById("gamesPlayed_l3").value;
var gamesPlayed_l4 = document.getElementById("gamesPlayed_l4").value;
var gamesPlayed_l5 = document.getElementById("gamesPlayed_l5").value;

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