import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { createBrowserRouter } from 'react-router';
import { RouterProvider } from 'react-router/dom';

import App from './App.tsx';
import VitePage from './Components/VitePage.tsx';
import EmployeeForm from './Components/Administration/EmployeeForm.tsx'


const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children: [
      {index: true, Component: VitePage},
      {path: "employeeform", Component: EmployeeForm}
    ]
  },
])

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
