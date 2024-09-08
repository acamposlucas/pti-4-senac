import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Link, Outlet } from "react-router-dom";

function App() {
  return (
    <div className="container">
      <header>
        <Link to={"home"}>Página inicial</Link>
      </header>
      <main className="mx-auto">
        <Outlet />
      </main>
    </div>
  );
}

export default App;
