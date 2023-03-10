
module.exports = {
    content: [
        './**/*.html',
        './**/*.razor',
        './Shared/**/*.razor'
    ],
    theme: {
        extend: {
            colors: {
                'rooster-gray-100': '#f7f7f7',
                'rooster-gray-200': '#eaeaea',
                'rooster-gray-250': '#e0e0e0',
                'rooster-gray-300': '#8e8e8e',
                'rooster-gray-350': '#828282',
                'rooster-gray-400': '#4c4c4c',
                'rooster-gray-600': '#373737',
                'rooster-gray-800': '#3f3f46',
                'rooster-gray-900': '#282828',
                'rooster-light-table-border': '#b3b3b3',
                'rooster-blue': '#1D7BBA',
                'rooster-red': '#B20000',
            },
            fontFamily: {
                'rooster': ['Proxima-Nova', 'URWDINCond-Demi', 'Arial', 'Tahoma', 'sans-serif'],
            },
            transitionProperty: {
                'width': "width",
                'max-width': "max-width",
                'min-width': "min-width",
                'height': "height",
                'max-height': "max-height",
            },
            width: {
                '16px': '16px',
                '32px': '32px',
            },
            height: {
                '0px': '0px',
                '16px': '16px',
                '32px': '32px',
            },
            boxShadow: {
                'sidebar': '0 .5rem 1rem rgba(0,0,0,.15)',
            },
            zIndex: {
                "-1": "-1",
            },
            transformOrigin: {
                "0": "0%",
            },
        }
    },
    plugins: [],
}
