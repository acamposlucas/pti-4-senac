import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { Home } from "./pages/Home/index.tsx";
import { Cadastro } from "./pages/Cadastro/index.tsx";
import { Login } from "./pages/Login/index.tsx";
import { CarteiraVacinacao } from "./pages/CarteiraVacinacao/index.tsx";
import { NovoMembro } from "./pages/NovoMembro/index.tsx";
import { NovoRegistro } from "./pages/NovoRegistro/index.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/",
        element: <Login />,
      },
      {
        path: "/cadastro",
        element: <Cadastro />,
      },
      {
        path: "/home",
        element: <Home />,
      },
      {
        path: "/carteiraVacinacao",
        element: <CarteiraVacinacao />,
      },
      {
        path: "/novoMembro",
        element: <NovoMembro />,
      },
      {
        path: "/novoRegistro",
        element: <NovoRegistro />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
