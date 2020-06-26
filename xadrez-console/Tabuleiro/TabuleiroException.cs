using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    class tabuleiroException:Exception {
        public tabuleiroException(string msg):base(msg) {
        }
    }
}
