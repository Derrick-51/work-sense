import { Outlet } from 'react-router'
import { ThemeProvider, createTheme } from '@mui/material/styles'

const lightTheme = createTheme({
  palette: {
    mode: "light",
  },
});

function App() {
  return (
    <>
      <ThemeProvider theme={lightTheme}>
        <Outlet />
      </ThemeProvider>
    </>
  )
}

export default App