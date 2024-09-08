import { FormEvent, useContext, useRef } from "react";
import { Button, Form } from "react-bootstrap";
import { LoginDTO } from "../../@types/LoginDTO";
import { UsuarioLogado } from "../../@types/UsuarioLogado";
import UserContext from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";

export function Login() {
  const { setUser } = useContext(UserContext);
  const navigate = useNavigate();

  const loginFormRef = useRef<HTMLFormElement>(null);

  async function handleFormSubmit(e: FormEvent) {
    e.preventDefault();

    const formData = new FormData(loginFormRef.current as HTMLFormElement);

    const dto: LoginDTO = {
      username: formData.get("username") as string,
      password: formData.get("password") as string,
    };

    try {
      const response = await fetch("https://localhost:7168/api/Auth/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dto),
      });

      if (!response.ok) {
        const data = await response.json();
        let msgErro = "";
        if (data.erro) {
          msgErro = data.erro;
        }
        throw new Error(`Não foi possível realizar o login: ${msgErro}`);
      }

      const data: UsuarioLogado = await response.json();

      setUser(data);
      resetForm();
      navigate("/home");
    } catch (error) {
      alert(error);
    }

    function resetForm() {
      formData.forEach((_, key) => {
        const input = loginFormRef.current?.elements.namedItem(
          key as string
        ) as HTMLInputElement | null;
        if (input) {
          input.value = "";
        }
      });
    }
  }

  return (
    <Form onSubmit={handleFormSubmit} ref={loginFormRef}>
      <h2>Login</h2>
      <Form.Group>
        <Form.Label>Usuário</Form.Label>
        <Form.Control type="text" name="username" required />
      </Form.Group>
      <Form.Group>
        <Form.Label>Senha</Form.Label>
        <Form.Control type="password" name="password" required />
      </Form.Group>
      <Button type="submit" variant="primary">
        Entrar
      </Button>
    </Form>
  );
}


