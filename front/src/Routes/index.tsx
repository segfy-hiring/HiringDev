import { lazy, Suspense } from 'react';
import CircularProgress from '@material-ui/core/CircularProgress';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Template from 'Components/Template';

const HomePage = lazy(() => import('Pages/Home'));

const RoutesWrapper = () => {
  return (
    <Suspense fallback={<CircularProgress />}>
      <BrowserRouter>
        <Routes>
          <Route element={<Template />}>
            <Route path="/" element={<HomePage />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </Suspense>
  );
};

export default RoutesWrapper;
