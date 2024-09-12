import React from "react";
import { useLocalStorage } from "../hooks/useLocalStorage";
import { UsuarioLogado } from "../@types/UsuarioLogado";

type PropsUserContext = {
	user: UsuarioLogado | null;
	setUser: React.Dispatch<React.SetStateAction<UsuarioLogado | null>>;
	validateLogin: (payload: { email: string; senha: string }) => void;
	handleUserLogout: () => void;
};

const UserContext = React.createContext<PropsUserContext>({} as PropsUserContext);

const UserContextProvider = ({ children }: { children: React.JSX.Element }) => {
	const [user, setUser] = useLocalStorage<UsuarioLogado | null>("user", null);

	function validateLogin(payload: { email: string; senha: string }) {
		// implementar com a tela de login
	}

	function handleUserLogout() {
		setUser((state) => null);
	}

	return (
		<UserContext.Provider value={{ user, setUser, validateLogin, handleUserLogout }}>
			{children}
		</UserContext.Provider>
	);
};

export { UserContextProvider };
export default UserContext;
