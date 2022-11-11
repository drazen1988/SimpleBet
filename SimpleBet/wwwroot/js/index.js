export function CounterUp() {
    let valueDisplays = document.querySelectorAll(".counter");
    let interval = 1000;
    console.log(valueDisplays);
    // My comment.
    valueDisplays.forEach((valueDisplay) => {
        let startValue = 0;
        let endValue = parseInt(valueDisplay.getAttribute("data-val"));
        console.log(endValue);
        let duration = Math.floor(interval / endValue);
        let counter = setInterval(function () {
            startValue += 1;
            valueDisplay.textContent = startValue;
            if (startValue == endValue) {
                clearInterval(counter);
            }
        }, duration);
    });
}
