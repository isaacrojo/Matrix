using System;

namespace Matrices
{
    class Matrix
    {
        private int[,] grid;            // la coma indica Bidimensional
        private int gridSize;

        public Matrix (int [,] gridValues, int gridSize){
            this.grid = gridValues;
            this.gridSize = gridSize;
        }

        public void PrintMatrix() {
            //iterar filas
            for(int y = 0; y < this.gridSize; y++) {
                //iterar columnas
                for (int x = 0; x < this.gridSize; x++) {
                    //print cada valor de la fila, columna
                    Console.Write(this.grid[y,x]);
                }
                //agregar salto de linea
                Console.WriteLine();
            }

        }

        public int CalculateDeterminantMexicanStyle() {
            return this.grid[0,0] * this.grid[1,1] * this.grid[2,2]
            + this.grid[0,1] * this.grid[1,2] * this.grid[2,0]
            + this.grid[0,2] * this.grid[1,0] * this.grid[2,1]
            - this.grid[0,2] * this.grid[1,1] * this.grid[2,0]
            - this.grid[0,0] * this.grid[1,2] * this.grid[2,1]
            - this.grid[0,1] * this.grid[1,0] * this.grid[2,2];
        }

        public int CalculateDeterminant() {
            int resultado = 0;

            //iterar primeras 3 diagonales (sumas)
            for (int i = 0; i < this.gridSize; i++){
                int diagonalResult = 1;

                //calcular valor de Y aque siempre es 0, luego 1, luego 2
                for (int y = 0; y < this.gridSize; y++) {
                    //calcular x
                    //la x es 0, luego 1, luego 2 pero dependiendo del # se le suma un numero
                    int x = y + i;

                    if (x >= this.gridSize) {
                        x = x - this.gridSize;
                    }
                    diagonalResult = diagonalResult * this.grid[y,x];
                }

                resultado += diagonalResult;
                //resultado = resultado + diagonalResult; (es lo mismo que arriba, combina operador)
            }


            //iterar segundas 3 diagonales (resta)
            for (int i = 0; i < this.gridSize; i++){

                int diagonalResult = 1;

                //calcular valor de Y que siempre es 0, luego 1, luego 2
                for (int y = 0; y < this.gridSize; y++) {
                    int x = (this.gridSize - 1) - y;

                    x -= i * (this.gridSize - 1);

                    while (x < 0) {
                        x += this.gridSize; 
                    }
                    diagonalResult *= this.grid[y,x];
                }
                resultado -= diagonalResult;
            }

            return resultado;
        }
    }
}
