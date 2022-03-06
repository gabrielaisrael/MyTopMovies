import './App.css';
import Categories from './components/Categories';
import FeaturedMovie from './components/FeaturedMovie';
import MovieRow from './components/MovieRow';

function App() {
  return (
    <div className="App">
      <Categories/>
      <FeaturedMovie/>
      <MovieRow/>
    </div>
  );
}

export default App;
