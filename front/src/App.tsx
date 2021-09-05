import React from 'react';
import { QueryClient, QueryClientProvider } from 'react-query';
import Routes from 'Routes';
import ThemeProvider from 'Theme';

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
      retry: 0,
    },
  },
});

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider>
        <Routes />
      </ThemeProvider>
    </QueryClientProvider>
  );
}

export default App;
