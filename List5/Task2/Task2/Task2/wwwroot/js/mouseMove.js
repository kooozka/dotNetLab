function initializeCanvas(canvasClass) {
    const canvasElements = document.querySelectorAll(canvasClass);
    canvasElements.forEach((canvas) => {
        console.log(canvas);
        const context = canvas.getContext("2d");
        let isDrawing = false;

        const drawLines = (x, y) => {
            if (!isDrawing) return;
            context.clearRect(0, 0, canvas.width, canvas.height);

            context.beginPath();
            context.moveTo(0, y);
            context.lineTo(x, y);
            context.stroke();

            context.beginPath();
            context.moveTo(x, 0);
            context.lineTo(x, y);
            context.stroke();

            context.beginPath();
            context.moveTo(x, canvas.height);
            context.lineTo(x, y);
            context.stroke();

            context.beginPath();
            context.moveTo(canvas.width, y);
            context.lineTo(x, y);
            context.stroke();

            context.beginPath();
            context.arc(x, y, 15, 0, Math.PI * 2);
            context.stroke();
        };

        canvas.addEventListener("mousemove", (event) => {
            const mouseX = event.clientX - canvas.getBoundingClientRect().left;
            const mouseY = event.clientY - canvas.getBoundingClientRect().top;
            drawLines(mouseX, mouseY);
        });

        canvas.addEventListener("mouseout", () => {
            isDrawing = false;
            context.clearRect(0, 0, canvas.width, canvas.height);
        });

        canvas.addEventListener("mouseenter", () => {
            isDrawing = true;
        });
    });
}
initializeCanvas(".canvas-cross");