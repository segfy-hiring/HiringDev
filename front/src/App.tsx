import React from 'react';
import Routes from 'Routes';
import ThemeProvider from 'Theme';

function App() {
  return (
    <ThemeProvider>
      <Routes />
    </ThemeProvider>
  );
}

export default App;
