import { useState } from 'react'
import { MantineProvider, SimpleGrid, Container, Stack } from '@mantine/core';
import {
	BrowserRouter,
	Routes,
	Route
} from "react-router-dom";

import AppHeader from 'src/components/header/AppHeader.jsx';
import GameList from 'src/scenes/GameList/GameList.jsx';
import Playground from './scenes/Playground/Playground.jsx';

function App() {
  	const [count, setCount] = useState(0);

  	const techTalkTheme = {
		fontFamily: 'Poppins',
		fontFamilyMonospace: 'Source Code Pro, Monaco, Courier, monospace',
		headings: { fontFamily: 'Poppins', fontWeight: '700' },
  	};

	return (
		<MantineProvider theme={techTalkTheme}>
			<Stack>
				<AppHeader />
				<BrowserRouter>
					<Routes>
						<Route path='/' element={<GameList />} />
						<Route path='/playground/:game' element={<Playground />} />
					</Routes>
				</BrowserRouter>
			</Stack>	
		</MantineProvider>
	)
}

export default App
