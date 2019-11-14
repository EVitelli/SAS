import { createMuiTheme } from "@material-ui/core/styles";

const theme = createMuiTheme({
  typography: {
    useNextVariants: true,
    fontFamily: '"Helvetica", "Arial", sans-serif',
    fontSize: 14,
    fontWeightLight: 300,
    fontWeightRegular: 400,
    fontWeightMedium: 500
  },
  palette: {
    primary: {
      light: "#63ccff",
      main: "#5c85d6",
      dark: "#006db3",
      contrastText: "#fff"
    },
    secondary: {
      light: "#63ccff",
      main: "#00a458",
      dark: "#006db3",
      contrastText: "#fff"
    }
  }
});

export default theme;
