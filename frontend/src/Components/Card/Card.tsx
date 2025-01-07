// Data type checking
interface Props {
  companyName: string;
  ticker: string;
  price: number;
}

const Card = ({ companyName, ticker, price }: Props) => {
  return (
    <div className="card">
      <img
        src="https://upload.wikimedia.org/wikipedia/commons/2/23/Black_and_white.jpg"
        alt="image"
      />
      <div className="details">
        <h2>
          {companyName}({ticker})
        </h2>
        <p>${price}</p>
      </div>
      <p className="info">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Ab cupiditate
        fuga commodi corrupti deleniti, error sint qui facere hic esse. Quis
        ipsum incidunt neque autem explicabo unde voluptates corporis ut?
      </p>
    </div>
  );
};

export default Card;
