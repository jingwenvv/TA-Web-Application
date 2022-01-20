
$('#chart').highcharts({
    chart: {
        type: 'line'
    },
    title: {
        text: 'Enrollments over time'
    },

    subtitle: {
        text: 'Enrollments over time'
    },

    yAxis: {
        title: {
            text: 'Students'
        }
    },

    xAxis: {

        title: {
            text: 'Date'
        },
        type: 'datetime',
        labels: {
            formatter: function () {
                return Highcharts.dateFormat('%m/%d',
                    this.value);
            }
        }
    },
    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            pointStart: startDate,
            pointInterval: 3600 * 1000 * 24,
            max: Date.UTC(2021, 11, 9)
        }
    },

    series: [{
        name: 'CS 4530',
        data: [113, 117, 122, 124, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125, 125]
    }],

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }
});



function update_DateTime() {
    var course = document.getElementById("course").value;
    var chart1 = $('#chart').highcharts();
    var exist = false;
    chart1.series.forEach(series => {
        if (series.name == course) {
            exist = true;
        }
    })
    if (exist == false) {
        chart1.addSeries(
            {
                name: course,
                data: [0]
            });
    }
    var date = new Date(document.getElementById("startDate").value);
    var date2 = new Date(document.getElementById("endDate").value);
    var utc_date = Date.UTC(date.getFullYear(), date.getMonth(), date.getDate() + 1);
    const diffTime = Math.abs(date2 - date);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    $(document).ajaxSend(function () {
        $("#overlay").fadeIn(500);
    });

    chart1.series.forEach(series => {
        var params =
        {
            start: (date.getMonth() + 1).toString().concat('/', (date.getDate() + 1).toString()),
            end: (date2.getMonth() + 1).toString().concat('/', (date2.getDate() + 1).toString()),
            course: series.name,
            days: diffDays
        };


        $.post("/Admin/GetEnrollmentData", params)
            .done(function (result) {
                series.update({
                    pointStart: utc_date,
                    data: result
                })
            }).fail(function () {
                alert('Failed to Send Data to set');
            });

    })
    setTimeout(function () {
        $("#overlay").fadeOut(1000);
    }, 500);
    chart1.redraw();
    console.log(date);
}

function add_series() {

    var params =
    {
        course: "CS 1400"
    };

    $.post("/Admin/GetEnrollmentData", params)
        .done(function (result) {
            $("#chart").highcharts().addSeries(
                {
                    name: "CS 1400",
                    data: result
                });
        });
}


