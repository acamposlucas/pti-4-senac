import { FormEvent, useContext, useRef } from "react";
import { Button, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import UserContext from "../../contexts/UserContext";
import { NovoMembroDTO } from "../../@types/NovoMembroDTO";

export function NovoMembro() {
  const { user } = useContext(UserContext);
  const navigate = useNavigate();

  const membroFormRef = useRef<HTMLFormElement>(null);

  async function handleFormSubmit(e: FormEvent) {
    e.preventDefault();

    const formData = new FormData(membroFormRef.current as HTMLFormElement);

    const novoMembro: NovoMembroDTO = {
      nome: formData.get("nome") as string,
      dataNascimento: new Date(formData.get("dataNascimento") as string),
      familiaId: user?.familiaId as number,
    };

    try {
      const response = await fetch("https://localhost:7168/api/Membro", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(novoMembro),
      });

      if (!response.ok) {
        const data = await response.json();
        let msgErro = "";
        if (data.erro) {
          msgErro = data.erro;
        }
        throw new Error(`Não foi possível cadastrar o membro: ${msgErro}`);
      }

      resetForm();
      navigate("/home");
    } catch (error) {
      alert(error);
    }

    function resetForm() {
      formData.forEach((_, key) => {
        const input = membroFormRef.current?.elements.namedItem(
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
      <h1>Cadastrar Novo Membro</h1>
      <Form action="" onSubmit={handleFormSubmit} ref={membroFormRef}>
        <legend hidden={true}>Novo Membro</legend>
        <Form.Group>
          <Form.Label htmlFor="nome">Nome</Form.Label>
          <Form.Control
            className="mb-3"
            type="text"
            id="nome"
            name="nome"
            placeholder="Digite o nome"
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label htmlFor="dataNascimento">Data de Nascimento</Form.Label>
          <Form.Control
            className="mb-3"
            type="date"
            id="dataNascimento"
            name="dataNascimento"
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
