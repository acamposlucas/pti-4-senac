import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Link, Outlet } from "react-router-dom";

function App() {
  return (
    <>
      <header>
        <Link to={"home"}>Página inicial</Link>
      </header>
      <main>
        <Outlet />
      </main>
    </>
  );
}

export default App;
