//Get mouse position by using event.client//////////////////////////////////////////////////

document.addEventListener('mousemove', function (event) {
    // Get the X and Y mouse positions from the event object
    const mouseX = event.clientX;
    const mouseY = event.clientY;

    // Update the text content of the respective elements with the mouse positions
    document.getElementById('mouseX').textContent = mouseX;
    document.getElementById('mouseY').textContent = mouseY;
});


//Fetch list from backend//////////////////////////////////////////////////


document.getElementById('showList').addEventListener('click', function () {
    fetch('/home/getpersons')
        .then(response => response.json())
        .then(persons => {
            const personList = document.getElementById('personList');

            personList.innerHTML = '';

            persons.forEach(person => {
                const li = document.createElement('li');
                li.textContent = `${person.name}`;
                personList.appendChild(li);
            });
        })
        .catch(error => console.error(error));
});

//Digital clock function//////////////////////////////////////////////////

//updates the clock every second
$(document).ready(function () {
    clockUpdate();
    setInterval(clockUpdate, 1000);
})

function clockUpdate() {
    //Set new date
    var date = new Date();

    //Gets class
    $('.digital-clock').css({ 'color': '#fff' });
    function addZero(x) {
        if (x < 10) {
            return x = '0' + x;
        } else {
            return x;
        }
    }
    //Goes back to 1 passed 12
    function twelveHour(x) {
        if (x > 12) {
            return x = x - 12;
        } else if (x == 0) {
            return x = 12;
        } else {
            return x;
        }
    }
     //get hours from the date and add zero if is less than 10 and goes back to zero if is passed 12 (not using military time). 
     //To use military time: addZero(date.getHours())
    var h = addZero(twelveHour(date.getHours()));
    //get minutes from the date and add zero if is less than 10
    var m = addZero(date.getMinutes());
    //get seconds from the date and add zero if is less than 10
    var s = addZero(date.getSeconds());

    //Adds text to digital-clock class
    $('.digital-clock').text(h + ':' + m + ':' + s)
}