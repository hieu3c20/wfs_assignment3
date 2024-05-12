// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

let labelsForBar = JSON.parse(document.getElementById("categoryNames").value).map(String);
let dataForBar = JSON.parse(document.getElementById("totalPostsPerCategories").value);
console.log(labelsForBar);
console.log(dataForBar);

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
  type: 'pie',
  data: {
    labels: labelsForBar,
    datasets: [{
      data: dataForBar,
      backgroundColor: getRandomColor(labelsForBar.length)
    }],
  },
});

function getRandomColor(length) { //generates random colours and puts them in string
  let colors = [];
  for (let i = 0; i < length; i++) {
    let letters = '0123456789ABCDEF'.split('');
    let color = '#';
    for (let x = 0; x < 6; x++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    colors.push(color);
  }
  return colors;
}