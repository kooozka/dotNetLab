var size = window.prompt("Input the size of the multiplication table");

        if (size < 5 || size > 20) {
            size = 10;
            document.getElementById("infoParagraph").innerText = "Size of the table set to the default value = 10";
        }
        const numbersArray = new Array();
        for (let i = 1; i <= size; i++) {
            numbersArray[i] = Math.floor(Math.random() * 99) + 1;
        }

        const table = document.getElementById("multiplicationTable");

        for (let rowNumber = 0; rowNumber <= size; rowNumber++) {
            const row = document.createElement("tr");
            for (let columnNumber = 0; columnNumber <= size; columnNumber++) {
                const cell = document.createElement(rowNumber == 0 || columnNumber == 0 ? "th" : "td");
                if (rowNumber != 0 && columnNumber != 0){
                    var result = numbersArray[columnNumber] * numbersArray[rowNumber];
                    cell.textContent = numbersArray[columnNumber] * numbersArray[rowNumber];
                    if (result % 2 == 0) {
                        cell.id = "even";
                    } else {
                        cell.id = "odd";
                    }
                } else if (rowNumber == 0 && columnNumber != 0) {
                    cell.textContent = numbersArray[columnNumber];
                } else{
                    cell.textContent = numbersArray[rowNumber];
                }
                row.appendChild(cell);
            }
            table.appendChild(row);
        }
        console.log(numbersArray);