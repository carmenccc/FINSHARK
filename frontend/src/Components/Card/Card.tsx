// Data type checking
interface Props {
  companyName: string;
  ticker: string;
  price: number;
}

// Type the function:
//      React.FC<Props> -- defines the type and prop types for the whole function
//                          <Props>相当于:Props, 可以二选一，也可以都写
//      : JSX.Element   -- defines he return types
const Card: React.FC<Props> = ({
  companyName,
  ticker,
  price,
}: Props): JSX.Element => {
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
