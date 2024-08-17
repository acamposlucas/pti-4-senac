import { FormEvent, useRef } from "react";
import { CadastroDTO } from "../../@types/CadastroDTO";
import { Button, Form } from "react-bootstrap";

export function Cadastro() {
  const cadastroFormRef = useRef<HTMLFormElement>(null);
  const emailRef = useRef<HTMLInputElement>(null);
  const usuarioRef = useRef<HTMLInputElement>(null);
  const senhaRef = useRef<HTMLInputElement>(null);
  const confirmarSenhaRef = useRef<HTMLInputElement>(null);

  async function handleFormSubmit(e: FormEvent) {
    e.preventDefault();

    const formData = new FormData(cadastroFormRef.current as HTMLFormElement);

    const dto: CadastroDTO = {
      username: formData.get("username") as string,
      email: formData.get("email") as string,
      password: formData.get("password") as string,
    };

    try {
      const response = await fetch(
        "https://localhost:7168/api/Auth/Cadastrar",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(dto),
        }
      );

      if (!response.ok) {
        const data = await response.json();
        let msgErro = "";
        if (data.erro) {
          msgErro = data.erro;
        }
        throw new Error(`Não foi possível realizar o cadastro: ${msgErro}`);
      }

      const data = await response.json();

      resetForm();
    } catch (error) {
      alert(error);
    }

    function resetForm() {
      formData.forEach((_, key) => {
        const input = cadastroFormRef.current?.elements.namedItem(
          key as string
        ) as HTMLInputElement | null;
        if (input) {
          input.value = "";
        }
      });
    }
  }

  return (
    <div className="container">
      <h1>Faça o seu cadastro</h1>
      <Form action="" onSubmit={handleFormSubmit} ref={cadastroFormRef}>
        <legend hidden={true}>Faça o seu cadastro!</legend>
        <Form.Group>
          <Form.Label htmlFor="email">Email</Form.Label>
          <Form.Control
            className="mb-3"
            type="email"
            id="email"
            name="email"
            placeholder="Digite seu email"
            ref={emailRef}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label htmlFor="usuario">Usuário</Form.Label>
          <Form.Control
            className="mb-3"
            type="text"
            id="usuario"
            name="username"
            placeholder="Digite seu usuário"
            ref={usuarioRef}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label htmlFor="senha">Senha</Form.Label>
          <Form.Control
            className="mb-3"
            type="password"
            id="senha"
            name="password"
            ref={senhaRef}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label htmlFor="confirmarSenha">Confirme sua senha</Form.Label>
          <Form.Control
            className="mb-3"
            type="password"
            id="confirmarSenha"
            name="confirmarSenha"
            ref={confirmarSenhaRef}
            required
          />
        </Form.Group>
        <Button className="mx-auto d-block" variant="primary" type="submit">
          Cadastrar
        </Button>
      </Form>
    </div>
  );
}
