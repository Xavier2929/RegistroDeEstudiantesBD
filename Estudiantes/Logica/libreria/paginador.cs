using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.libreria
{
   public class paginador <T> 
    {
        //esta clase es una clase genera con los siguiente atributos

       private  List<T> _dataList;
        private Label _label;

        //esta informacion es statica para que mantenga un valor durante la ejecucion
        private static int maxReg, _reg_por_pagina, pageCount, numPag = 1;

        public paginador(List<T> dataList,Label label,int regPorPagina)
        {
            this._dataList = dataList;
           this. _label = label;
           _reg_por_pagina = regPorPagina;
            cargarDatos();

        }
        private void cargarDatos()
        {
            numPag = 1;
            //sacamos las paginas maximas
            maxReg = _dataList.Count;
            //verificamos cuantas paginas podemos crear con las siguiente variables
            pageCount = (maxReg / _reg_por_pagina);

            //ahora sacamos si tiene reciduo para saber si quedaron registros restantes y asi darles una pagina
            if (maxReg%_reg_por_pagina>0)
            {
                pageCount++;
            }
            _label.Text = $"Paginas 1/{pageCount}"; 
        }

        public int primero()
        {
            numPag = 1;
            _label.Text = $"Paginas {numPag}/{pageCount}";
            return numPag;
        }

        public int anterior()
        {
            if (numPag>1)
            {
                numPag -= 1;
                _label.Text = $"Paginas {numPag}/{pageCount}"; 
            }
            return numPag;
        }

        public int siguiente()
        {
            if (numPag == pageCount)
                numPag -=1;
            if (numPag<pageCount)
            {
                numPag += 1;
                _label.Text = $"Paginas {numPag}/{pageCount}";
            }
            return numPag;
           
        }

        public int ultimo()
        {
            numPag = pageCount;
            _label.Text = $"Paginas {numPag}/{pageCount}";
            return numPag;

        }

    }
}
