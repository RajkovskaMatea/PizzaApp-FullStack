export const getPriceBySize = () => {
        switch (+selectedSize) {
            case 0:
                return pizza.pizzaPriceSmall;
            case 1:
                return pizza.pizzaPriceMedium;
            case 2:
                return pizza.pizzaPriceLarge;
            default:
                return pizza.pizzaPriceLarge;
        }
    };
