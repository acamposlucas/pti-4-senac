import React, { useContext, useEffect, useRef, useState } from "react";
import UserContext from "../../contexts/UserContext";
import Card from "react-bootstrap/Card";
import { Button, Form, Modal } from "react-bootstrap";
import { Link } from "react-router-dom";

// Define a interface para os dados da família
interface Membro {
  id: number;
  familiaId: number;
  nome: string;
  dataNascimento: string;
  carteiraVacinacaoId: number;
}

interface Familia {
  familiaId: number;
  usuarioId: number;
  membros: Membro[];
}

export function Home() {
  const { user } = useContext(UserContext);
  const [familia, setFamilia] = useState<Familia | null>(null);
  const [atualizarFamilia, setAtualizarFamilia] = useState<boolean>(false);

  useEffect(() => {
    setAtualizarFamilia(false);

    fetch(`https://localhost:7168/api/Familia/${user?.familiaId}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        setFamilia(data);
      })
      .catch((error) => {
        console.error("Erro ao buscar dados:", error);
      });
  }, [atualizarFamilia]);

  if (!familia) {
    return <div>Carregando...</div>;
  }

  return (
    <div>
      <h1>Bem-vindo!</h1>
      <div className="mb-2">
        <Link to={"/novoMembro"}>
          {" "}
          <Button as="span" variant="primary">
            Adicionar membro
          </Button>
        </Link>
      </div>
      {familia.membros.length > 0 ? (
        familia.membros.map((membro) => (
          <MembroCard
            key={membro.id}
            membro={membro}
            setAtualizarFamilia={setAtualizarFamilia}
          />
        ))
      ) : (
        <p>Não há membros cadastrados</p>
      )}
    </div>
  );
}

interface MembroCardProps {
  membro: Membro;
  setAtualizarFamilia: React.Dispatch<React.SetStateAction<boolean>>;
}
function MembroCard({ membro, setAtualizarFamilia }: MembroCardProps) {
  const [showModalEditar, setShowModalEditar] = useState(false);

  const handleCloseModalEditar = () => setShowModalEditar(false);
  const handleShowModalEditar = () => setShowModalEditar(true);

  const editarMembroFormRef = useRef<HTMLFormElement>(null);

  async function handleDeletarMembro() {
    try {
      const response = await fetch(
        `https://localhost:7168/api/Membro/${membro.id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error("Não foi possível abrir os dados desse membro");
      }

      setAtualizarFamilia(true);
    } catch (error) {
      alert(error);
    }
  }

  async function handleEditarMembro() {
    const formData = new FormData(
      editarMembroFormRef.current as HTMLFormElement
    );

    const dto: Omit<Membro, "familiaId" | "carteiraVacinacaoId"> = {
      id: membro.id,
      nome: formData.get("nome") as string,
      dataNascimento: formData.get("dataNascimento") as string,
    };
    try {
      const response = await fetch(
        `https://localhost:7168/api/Membro/${membro.id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(dto),
        }
      );

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(
          `Request failed: ${response.status} ${response.statusText} - ${errorText}`
        );
      }

      setAtualizarFamilia(true);
      handleCloseModalEditar();
    } catch (error: any) {
      console.error("Falha na chamada à API:", error);
      alert("Falha ao atualizar imunização: " + error.message);
    }
  }
  return (
    <>
      <Card
        bg="primary"
        key={membro.id}
        text="white"
        style={{ width: "18rem" }}
        className="mb-2"
      >
        <Card.Header>{`Membro ID: ${membro.id}`}</Card.Header>
        <Card.Body>
          <Card.Title>{membro.nome}</Card.Title>
          <Card.Text>
            Data de Nascimento:{" "}
            {new Date(membro.dataNascimento).toLocaleDateString()}{" "}
            {/* Formatar data */}
          </Card.Text>
          <Card.Text>
            Carteira de Vacinação ID: {membro.carteiraVacinacaoId}
          </Card.Text>
        </Card.Body>
        <Card.Footer>
          <div className="btn-group">
            <Button as="span" variant="light">
              <Link
                to={`/carteiraVacinacao/${membro.id}`}
                style={{ textDecoration: "none" }}
              >
                Visualizar carteira
              </Link>
            </Button>
            <Button variant="info" onClick={handleShowModalEditar}>
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                fillRule="inherit"
                className="bi bi-pencil-square"
                viewBox="0 0 16 16"
              >
                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                <path
                  fillRule="evenodd"
                  d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"
                />
              </svg>
            </Button>
            <Button
              type="button"
              variant="danger"
              onClick={handleDeletarMembro}
            >
              Deletar
            </Button>
          </div>
        </Card.Footer>
      </Card>
      <Modal show={showModalEditar} onHide={handleCloseModalEditar}>
        <Modal.Header closeButton>
          <Modal.Title>Editar membro</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form ref={editarMembroFormRef}>
            <Form.Label id="nome" htmlFor="nome">
              Nome
            </Form.Label>
            <Form.Control
              type="text"
              name="nome"
              id="nome"
              defaultValue={membro.nome}
            ></Form.Control>
            <Form.Label
              id="dataNascimento"
              htmlFor="dataNascimento"
            ></Form.Label>
            <Form.Control
              type="date"
              name="dataNascimento"
              id="dataNascimento"
              defaultValue={membro.dataNascimento}
            ></Form.Control>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModalEditar}>
            Fechar
          </Button>
          <Button variant="primary" onClick={handleEditarMembro}>
            Salvar
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default Home;
