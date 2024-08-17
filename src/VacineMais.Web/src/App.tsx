import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Outlet } from "react-router-dom";

function App() {
  return (
    <>
      <main>
        <Outlet />
      </main>
    </>
  );
}

export default App;
